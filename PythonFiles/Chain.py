from Block import Block
from NoSSL import no_ssl_verification
import mysql.connector
import requests
import hashlib
import json

Id = "bank1Test"
url = "https://localhost:44357/"


class Chain:
    def __init__(self):
        self.currentHash = 0
        self.blocks = list()   # blocknumber, proof, previousHush
        self.BankId = Id

    # a quick verification that chain's hash is valid till final block
    def valid_chain(self, lastBlockId):
        num = 0
        newBlocks = self.getDbBlocks(self)
        for block in newBlocks:
             self.currentHush = block[1]
             answer = self.proofOfWork(block[0])
             if answer['ResponseType'] == 0:
                 newBlock = Block(block[0], block[2])
                 self.currentHush = self.Hash(newBlock)
                 if self.currentHush != block[1]:
                     deleteblockTransactions(newBlock.Id)
                     addTransaction(newBlock)
                     updateBlock(newBlock)
                     self.sendHash(newBlock.Id)
             elif answer['ResponseType'] == 2:
                 newBlock = Block(block[0], block[2])
                 self.resolveConflicts(newBlock, False)
             elif answer['ResponseType'] == 3:
                self.sendTransactions(block[0])
        num = block.Id
        for i in range(num + 1, lastBlockId):
            newBlock = (i, self.currentHush)
            self.currentHush = self.Hash(newBlock)
            answer = self.proofOfWork(i)
            if answer['ResponseType'] == 0:
                 addBlock(newBlock)
                 self.sendHash(newBlock.Id) #bank Id, blockId ,currentHash
            elif answer['ResponseType'] == 1:
                 addBlock(newBlock)
            elif answer['ResponseType'] == 2:
                 self.resolveConflicts(newBlock, True)
            elif answer['ResponseType'] == 3:
                addBlock(newBlock)
                self.sendTransactions(block[0])

    # changes data in block and DB by the consensus
    def resolveConflicts(self, block, isNew):
        self.currentHush = self.Hash(block)
        answer = self.proofOfWork(block.Id)
        if answer['ResponseType'] == 1:
            deleteblockTransactions(block.Id)
            addTransaction(block)
            if isNew:
                addBlock(block)
            else:
                updateBlock(block)
            self.sendHash(block.Id)
        if answer['ResponseType'] == 2:
            temp = url + "Transaction/CheckConsensus"
            payload = {'BlockchainNumber': block.Id}
            headers = {'Content-Type': 'application/json'}
            try:
                with no_ssl_verification():
                    response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                    if response.status_code == 200:
                        checkTransactions(response['transactionList'], block.Id)
            except requests.exceptions.RequestException as e:
                print(e)

    # a function to check that the block is in-sync with server
    def proofOfWork(self, blockId):
        temp = url + "Transaction/CheckHash/"
        payload = {'BlockchainNumber': blockId, 'Hush': self.currentHash}
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

    def Hash(self, newBlock):
        block_string = json.dumps(newBlock).encode()
        return hashlib.sha256(block_string).hexdigest()

    def sendHash(self, blockId):
        temp = url + "Transaction/SetHash"
        payload = {"BankId" : self.BankId, "BlockId" : blockId, "Hash": self.currentHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('Post', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)
            return response

    def sendTransactions(self, block):
        temp = url + "Transaction/SetTransactions"
        payload = {"transactionList" : block.data, "BlockId" : block.Id}
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
            args = [transaction, blockId]
            transactionDeleteList.append(args)
    for transaction in TransactionList:
        if transaction not in transactionsDB:
            args = [transaction, blockId]
            transactionUpdateList.append(args)
    addMoreTransactions(transactionUpdateList)
    deleteMoreTransactions(transactionDeleteList)


# adds transactions per consensus to DB
def addMoreTransactions(transactionUpdateList):
    connection = connect()
    cursor = connection.cursor()
    query = "INSERT INTO transactionsperblock (transactionId, blockId) VALUES(%s, %s)"
    cursor.executemany(query, transactionUpdateList)
    connection.commit
    cursor.close()


# deletes transactions per consensus from DB
def deleteMoreTransactions(transactionDeleteList):
    connection = connect()
    cursor = connection.cursor()
    query = "Delete From transactionsperblock (transactionId, blockId) VALUES(%s, %s)"
    cursor.executemany(query, transactionDeleteList)
    connection.commit
    cursor.close()


# Adds the new block to this bankDb
def addBlock(block):
    args = [block.Id, block.hush, block.previousBlockHash]
    sp ='addBlock'
    answer =UseDb(args, sp)
    addTransaction(block)


#  Adds transactions List to transactionperblock Table
def addTransaction(block):
    blockList = list()
    connection = connect()
    cursor = connection.cursor()
    query = "INSERT INTO transactionsperblock (transactionId, blockId) VALUES(%s, %s)"
    for transaction in block.data:
        args = [transaction['transactionId'],block.Id]
        blockList.append(args)
    cursor.executemany(query, blockList)
    connection.commit
    cursor.close()


# gets all the data of the blocks in the bankDb
def getDbBlocks():
    args = []
    sp = 'getAllBlocks'
    answer = UseDb(args, sp)
    return answer


# gets all the transactions written in this block
def getTransactions(blockId):
    args = [blockId]
    sp = 'getTransactionsperBlock'
    answer = UseDb(args, sp)
    return answer


# Updates the block in this bankDb
def updateBlock(block):
    args = [block.Id, block.hush, block.previousBlockHash]
    sp = 'updateBlock'
    UseDb(args, sp)


# Deletes all transaction that were in this block.
def deleteblockTransactions(blockId):
    sp = 'deleteTransactions'
    args = [blockId]
    answer = UseDb(args, sp)


# A function get procedure name and argumens and use the stored procedure in his BankDB.
def UseDb(args, sp):
    connection = connect()
    cursor = connection.cursor()
    cursor.callproc(sp, args)
    answer = list(next(cursor.stored_results()))
    connection.commit
    cursor.close()
    return answer


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
    newblock = Block(1,None)
    answer = chain.isBlockReady()
    chain.valid_chain(answer['blockchainNumber'])


if __name__ == '__main__':
    main()

