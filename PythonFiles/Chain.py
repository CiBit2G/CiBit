import hashlib
import json

import mysql.connector
import requests

from Block import Block
from NoSSL import no_ssl_verification

Id = "bank1Test"
url = "https://localhost:5001/"


class Chain:
    def __init__(self):
        self.currentHash = 0
        self.blocks = list()   # blocknumber, proof, previousHush
        self.BankId = Id

    # a quick verification that chain's hash is valid till final block
    def valid_chain(self, lastBlockId):
        num = 0
        newBlocks = getDbBlocks()
        for block in newBlocks:
             answer = self.proofOfWork(block[0], block[1])
             if answer == 0:
                 newBlock = Block(block[0], self.currentHash)
                 self.currentHash = self.Hash(newBlock)
                 self.sendHash(newBlock.Id, newBlock.previousBlockHash)
                 if self.currentHash != block[1]:
                     deleteBlockTransactions(newBlock.Id)
                     addTransaction(newBlock)
                     self.updateBlock(newBlock)
             elif answer == 1:
                 self.currentHash = block[1]
             elif answer == 2:
                 newBlock = Block(block[0], block[2])
                 self.resolveConflicts(newBlock, False)
             elif answer == 3:
                sendTransactions(block[0])
                self.currentHash = block[1]
        num = len(newBlocks)
        for i in range(num, lastBlockId + 1):
            newBlock = Block(i, self.currentHash)
            self.currentHash = self.Hash(newBlock)
            self.addBlock(newBlock)
            answer = self.proofOfWork(i, self.currentHash)
            if answer == 0:
                self.sendHash(newBlock.Id, newBlock.previousBlockHash) # bank Id, blockId ,currentHash
            elif answer == 2:
                self.resolveConflicts(newBlock, True)
            elif answer == 3:
                sendTransactions(block[0])

    # changes data in block and DB by the consensus
    def resolveConflicts(self, block, isNew):
        self.currentHash = self.Hash(block)
        answer = self.proofOfWork(block.Id, self.currentHash)
        if answer == 1:
            deleteBlockTransactions(block.Id)
            addTransaction(block)
            self.updateBlock(block)
            self.sendHash(block.Id, block.previousBlockHash)
        if answer == 2:
            temp = url + "Transaction/CheckConsensus"
            payload = {'BlockchainNumber': block.Id}
            headers = {'Content-Type': 'application/json'}
            try:
                with no_ssl_verification():
                    response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                    if response.status_code == 200:
                        answer = response.json()
                        self.currentHash = answer['hash']
                        checkTransactions(answer['transactionList'], block.Id)
                        self.updateHash(block.Id)
            except requests.exceptions.RequestException as e:
                print(e)

    # a function to check that the block is in-sync with server
    def proofOfWork(self, blockId, currentHash):
        temp = url + "Transaction/CheckHash/"
        payload = {'BlockchainNumber': blockId, 'Hash': currentHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                return response.json()
        except requests.exceptions.RequestException as e:
            print(e)

    # a function to check if block is ready to be filled with data and have a consensus
    def isBlockReady(self):
        temp = url + "Transaction/BlockReady/"
        payload = {}
        headers = {}
        with no_ssl_verification():
            response = requests.request("GET", url=temp, headers=headers, data=payload)
        if response.status_code != 200:
            return -1
        return response.json()

    # a function to hash the current block
    def Hash(self, newBlock):
        tempString = {'blockId': newBlock.Id, 'transactions': newBlock.data, 'previousHash': newBlock.previousBlockHash }
        blockString = json.dumps(tempString).encode()
        return hashlib.sha256(blockString).hexdigest()

    # sends the current Hash to server
    def sendHash(self, blockId, previousHash):
        temp = url + "Transaction/SetHash"
        payload = {"BankId": self.BankId, "BlockchainNumber": blockId, "Hash": self.currentHash, "PreviousHash": previousHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('Post', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)

    # Adds the new block to this BankDB
    def addBlock(self, block):
        args = [block.Id, self.currentHash, block.previousBlockHash]
        sp = 'addBlock'
        useDb(args, sp)
        addTransaction(block)

    # Updates the block in this BankDB
    def updateBlock(self, block):
        args = [block.Id, self.currentHash, block.previousBlockHash]
        sp = 'updateBlock'
        useDb(args, sp)

    # Updates the Hash of current Block in BankDB
    def updateHash(self, blockId):
        args = [blockId, self.currentHash]
        sp = 'updateHash'
        useDb(args, sp)


# Sends transactions to server
def sendTransactions(blockId):
        if blockId == 0:
            return
        temp = url + "Transaction/SetTransaction"
        transactionsDB = getTransactions(blockId)
        payload = {"BlockchainNumber": blockId, "TransactionArr": transactionsDB}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('Post', url=temp, headers=headers, data=json.dumps(payload))
                return response
        except requests.exceptions.RequestException as e:
            print(e)
            return False


# deletes or adds transactions per consensus
def checkTransactions(TransactionList, blockId):
    transactionDeleteList = list()
    transactionUpdateList = list()
    transactionsDB = getTransactions(blockId)
    for transaction in transactionsDB:
        if transaction not in TransactionList:
            args = (transaction, blockId)
            transactionDeleteList.append(args)
    for transaction in TransactionList:
        if transaction not in transactionsDB:
            args = (transaction, blockId)
            transactionUpdateList.append(args)
    try:
        deleteMoreTransactions(transactionDeleteList)
        addMoreTransactions(transactionUpdateList)
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)


# adds transactions per consensus to DB
def addMoreTransactions(transactionUpdateList):
    connection = connect()
    cursor = connection.cursor()
    query = "INSERT INTO transactionsperblock(transactionId, blockId) VALUES(%s, %s)"
    cursor.executemany(query, transactionUpdateList)
    connection.commit()
    cursor.close()


# deletes transactions per consensus from DB
def deleteMoreTransactions(transactionDeleteList):
    connection = connect()
    cursor = connection.cursor()
    query = "Delete From transactionsperblock (transactionId, blockId) VALUES(%s, %s)"
    cursor.executemany(query, transactionDeleteList)
    connection.commit()
    cursor.close()


#  Adds transactions List to transactionperblock Table
def addTransaction(block):
    blockList = list()
    for transaction in block.data:
        args = [transaction['transactionId'], block.Id]
        blockList.append(args)
    addMoreTransactions(blockList)


# gets all the data of the blocks in the bankDb
def getDbBlocks():
    args = None
    sp = 'getAllBlocks'
    answer = useReturnDb(args, sp)
    return answer


# gets all the transactions written in this block, return transaction inside a list.
def getTransactions(blockId):
    transactionList =list()
    args = [blockId]
    sp = 'getTransactionsperBlock'
    answers = useReturnDb(args, sp)
    for answer in answers:
        transactionList.append(answer[0])
    return transactionList


# Deletes all transaction that were in this block.
def deleteBlockTransactions(blockId):
    sp = 'deleteTransactions'
    args = [blockId]
    useDb(args, sp)


# A function that uses BankDb and return an answer.
def useReturnDb(args, sp):
    connection = connect()
    cursor = connection.cursor()
    try:
        if args is None:
             cursor.callproc(sp)
        else:
            cursor.callproc(sp, args)
        answer = list(next(cursor.stored_results()))
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)
    connection.commit()
    cursor.close()
    return answer


# A function that uses BankDb without any answers.
def useDb(args, sp):
    connection = connect()
    cursor = connection.cursor()
    try:
        cursor.callproc(sp, args)
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)
    connection.commit()
    cursor.close()


def connect():
    try:
        connection = mysql.connector.connect(host='localhost',
                                         database='bankdb',
                                         user='chain',
                                         password='qwe32110',
                                         auth_plugin='mysql_native_password')
        return connection
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)


def main():
    chain = Chain()
    answer = chain.isBlockReady()
    chain.valid_chain(answer['blockchainNumber'])


if __name__ == '__main__':
    main()

