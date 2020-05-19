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
        self.currentHash = 100
        self.blocks = list()   # blocknumber, proof, previousHush
        self.BankId = Id

    # a quick verification that chain's hash is valid till final block
    def valid_chain(self, lastBlockId):
        num = 0
        newBlocks = getDbBlocks()
        for block in newBlocks:
             self.currentHash = block[1]
             answer = self.proofOfWork(block[0])
             if answer == 0:
                 newBlock = Block(block[0], block[2])
                 self.currentHash = self.Hash(newBlock)
                 if self.currentHash != block[1]:
                     deleteBlockTransactions(newBlock.Id)
                     addTransaction(newBlock)
                     self.updateBlock(newBlock)
                     self.sendHash(newBlock.Id)
             elif answer == 2:
                 newBlock = Block(block[0], block[2])
                 self.resolveConflicts(newBlock, False)
             elif answer == 3:
                self.sendTransactions(block[0])
             num = block.Id
        for i in range(num + 1, lastBlockId):
            newBlock = Block(i, self.currentHash)
            self.currentHash = self.Hash(newBlock)
            answer = self.proofOfWork(i)
            if answer == 0:
                self.addBlock(newBlock)
                self.sendHash(newBlock.Id) # bank Id, blockId ,currentHash
            elif answer == 1:
                self.addBlock(newBlock)
            elif answer == 2:
                self.resolveConflicts(newBlock, True)
            elif answer == 3:
                self.addBlock(newBlock)
                self.sendTransactions(block[0])

    # changes data in block and DB by the consensus
    def resolveConflicts(self, block, isNew):
        self.currentHush = self.Hash(block)
        answer = self.proofOfWork(block.Id)
        if answer == 1:
            deleteBlockTransactions(block.Id)
            addTransaction(block)
            if isNew:
                self.addBlock(block)
            else:
                self.updateBlock(block)
            self.sendHash(block.Id)
        if answer == 2:
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

    # a function to hash the block
    def Hash(self, newBlock):
        tempString = {'blockId': newBlock.Id, 'transactions': newBlock.data, 'previousHash': newBlock.previousBlockHash }
        blockString = json.dumps(tempString).encode()
        return hashlib.sha256(blockString).hexdigest()

    # sends the current Hash to DB
    def sendHash(self, blockId):
        temp = url + "Transaction/SetHash"
        payload = {"BankId": self.BankId, "BlockchainNumber": blockId, "Hash": self.currentHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('Post', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)

    # Adds the new block to this bankDb
    def addBlock(self, block):
        args = [block.Id, self.currentHash, block.previousBlockHash]
        sp = 'addBlock'
        useDb(args, sp)
        addTransaction(block)

    # Updates the block in this bankDb
    def updateBlock(self, block):
        args = [block.Id, self.currentHash, block.previousBlockHash]
        sp = 'updateBlock'
        useDb(args, sp)


# Sends transactions to DB
def sendTransactions(block):
        temp = url + "Transaction/SetTransactions"
        payload = {"transactionList": block.data, "BlockId": block.Id}
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
    query = "INSERT INTO transactionsperblock(transactionId, blockId) VALUES(%s, %s)"
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


#  Adds transactions List to transactionperblock Table
def addTransaction(block):
    blockList = list()
    for transaction in block.data:
        args = [transaction['transactionId'],block.Id]
        blockList.append(args)
    addMoreTransactions(blockList)


# gets all the data of the blocks in the bankDb
def getDbBlocks():
    args = None
    sp = 'getAllBlocks'
    answer = useReturnDb(args, sp)
    return answer


# gets all the transactions written in this block
def getTransactions(blockId):
    args = [blockId]
    sp = 'getTransactionsperBlock'
    answer = useReturnDb(args, sp)
    return answer


# Deletes all transaction that were in this block.
def deleteBlockTransactions(blockId):
    sp = 'deleteTransactions'
    args = [blockId]
    useDb(args, sp)


# A function get procedure name and argumens and use the stored procedure in his BankDB.
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
    connection.commit
    cursor.close()
    return answer


def useDb(args, sp):
    connection = connect()
    cursor = connection.cursor()
    try:
        cursor.callproc(sp, args)
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)
    connection.commit
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

