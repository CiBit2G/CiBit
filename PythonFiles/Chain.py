from Block import Block
from NoSSL import no_ssl_verification
import mysql.connector
import requests

Id = "bank1Test"
url = "https://localhost:44357/"


class Chain:
    def __init__(self):
        self.currentHash is None
        self.blocks = list() #blocknubmer, proof, previousHush
        self.BankId = Id

    # a quick verfication that chain's hash is valid till final block
    def valid_chain(self, lastBlockInDbNubmer, lastBlockId):
        newblocks = self.getDbBlocks(self)
        for blook in newblocks:
            if self.proofOfWork(blook) != 1:
                newBlock = self.resolveConflicts(blook)
                self.updateBlock(newBlock)
        for i in range(lastBlockInDbNubmer +1, lastBlockId):
            newBlock = (i, self.blocks[-1].hush)
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
        newBlock = Block()
        return True

    #
    def proofOfWork(self, last_block):
        return True

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

    def addBlock(self, block):
        cursor =connect().cursor()
        args =[block.Id, block.hush, block.previousBlockHash]
        cursor.callproc('addBlock',args)
        cursor.close()

    def updateBlock(self, block):
        cursor =connect().cursor()
        args =[block.Id, block.hush, block.previousBlockHash]
        cursor.callproc('updateBlock',args)
        cursor.close()

    def getCurrentState(self):
        cursor =connect().cursor()
        cursor.callproc('GetLastBlock')
        answer =list(next(cursor.stored_results()))
        cursor.close()
        return answer

    def getDbBlocks(self):
        cursor =connect().cursor()
        cursor.callproc('getAllBlocks')
        answer =list(next(cursor.stored_results()))
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
    chain =Chain()
    blockInfo =chain.isBlockReady()
    #get block and hash from DB - if block = blockinfo and hash - blockinfo.hash return
    check = chain.getCurrentState()
    if check[0] == blockInfo['BlockchainNumber'] and check[1] == blockInfo['Proof']:
        return
    else:
        chain.valid_chain(blockInfo['BlockchainNumber'])


if __name__ == '__main__':
    main()

