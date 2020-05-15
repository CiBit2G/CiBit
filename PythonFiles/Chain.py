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
            if self.proofOfWork(block) != 1:
                newBlock = self.resolveConflicts(block)
                self.updateBlock(newBlock)
            num = block.Id
        for i in range(num + 1, lastBlockId):
            newBlock = self(i, self.blocks[-1].hush)
            checkResult = self.proofOfWork(newBlock)
            if checkResult == 1:
                self.addBlock(newBlock)
            elif checkResult == 0:
                self.blocks.append(newBlock)
                self.addBlock(newBlock)
                self.sendData(newBlock)
            else:
                self.resolveConflicts(newBlock)
        return True

    # changes data in block and DB by the consensus
    def resolveConflicts(self, block):
        temp = url + "Transaction/CheckConsensus"
        payload = {'bankId': self.BankId, 'BlockchainNumber': block.Id}
        headers = {'Content-Type': 'application/json'}
    # replace with method - delete from table,check block, insert to table
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                if response['Hash'] == self.hash:
                    return block
                else:
                    return response
        except requests.exceptions.RequestException as e:
            print(e)
        newBlock = Block()
        return True

    # a function to check that the block is in-sync with server
    def proofOfWork(self,block):
        temp = url + "Transaction/CheckHash/"
        payload = {'BlockchainNumber': block.Id, 'Hush': self.currentHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                return response
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

    def checkTransactions(self):
        return True

    def Hash(self, index):
        block_string = json.dumps(self.blocks[index]).encode()
        self.currentHash = hashlib.sha256(block_string).hexdigest()


# Need to Fix all repeated code and use a function to call querys/sp
# Adds the new block to this bankDb
def addBlock(block):
    blockList = list()
    connection = connect()
    cursor = connection.cursor()
    args = [block.Id, block.hush, block.previousBlockHash]
    cursor.callproc('addBlock',args)
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


# Updates the block in this bankDb
def updateBlock( block):
    args = [block.Id, block.hush, block.previousBlockHash]
    sp = 'updateBlock'
    UseDb(args, sp)


def deleteblockTransactions(blockId):
    sp = 'deleteTransactions'
    args = [blockId]
    answer = UseDb(args, sp)


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

