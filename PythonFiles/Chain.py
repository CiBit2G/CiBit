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
        self.blocks = list() #blocknubmer, proof, previousHush
        self.BankId = Id

    # a quick verification that chain's hash is valid till final block
    def valid_chain(self, lastBlockInDbNumber, lastBlockId):
        newBlocks = self.getDbBlocks(self)
        for block in newBlocks:
            if self.proofOfWork(block) != 1:
                newBlock = self.resolveConflicts(block)
                self.updateBlock(newBlock)
        for i in range(lastBlockInDbNumber + 1, lastBlockId):
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
    def resolveConflicts(self, blook):
         #replace with method - delete from table,check block, insert to table
        newBlock = Block()
        return True

    # a function to check that the block is in-sync with server
    def proofOfWork(self,block):
        temp = url + "Transaction/CheckHash/"
        payload = {'BlockchainNumber': block.Id,
                  'Hush': self.currentHash}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)
        return response

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

    # Adds the new block to this bankDb
    def addBlock(self, block):
        cursor = connect().cursor()
        args = [block.Id, block.hush, block.previousBlockHash]
        # NEED TO CREATE LIST OF TRANSACTIONID WITH BLOCKID(STAYS THE SAME)
        # EXCUTEMANY
        cursor.callproc('addBlock',args)
        cursor.close()

    # Updates the block in this bankDb
    def updateBlock(self, block):
        cursor = connect().cursor()
        args = [block.Id, block.hush, block.previousBlockHash]
        cursor.callproc('updateBlock',args)
        cursor.close()

    def getCurrentState(self):
        cursor = connect().cursor()
        cursor.callproc('GetLastBlock')
        answer = list(next(cursor.stored_results()))
        cursor.close()
        return answer

    # gets all the data of the blocks in the bankDb
    def getDbBlocks(self):
        cursor = connect().cursor()
        cursor.callproc('getAllBlocks')
        answer = list(next(cursor.stored_results()))
        cursor.close()
        return answer

    def Hash(self, index):
        block_string = json.dumps(self.blocks[index]).encode()
        self.currentHash = hashlib.sha256(block_string).hexdigest()

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
    check = chain.getCurrentState()
    if check[0] == answer['blockchainNumber'] and check[1] == answer['hash']:
        return
    chain.valid_chain(check[0], answer['blockchainNumber'])


if __name__ == '__main__':
    main()

