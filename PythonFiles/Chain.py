from Block import Block
from NoSSL import no_ssl_verification
import mysql.connector
import requests

Id = "bank1Test"
url = "https://localhost:44357/"


class Chain:
    def __init__(self):
        self.currentHash is None
        self.blocks = list() #blocknubmer,previousHush, proof
        self.BankId = Id

    # a quick verfication that chain's hash is valid till final block
    def valid_chain(self, lastBlockInDbNubmer, lastBlockId):
        self.getDbBlocks(self)
        for blook in self.blocks:
            if self.checkBlock(blook) != 1:
                newBlock = self.resolve_conflicts(blook)
                self.updateBlock(newBlock)
        for i in range(lastBlockInDbNubmer +1, lastBlockId):
            newBlock = (i, self.blocks[-1].hush)
            checkResult = self.checkBlock(newBlock)
            if checkResult == 1:
                self.blocks.append(newBlock)
                self.addBlock(newBlock)
            elif checkResult == 0:
                self.proof_of_work(newBlock)
                self.blocks.append(newBlock)
                self.addBlock(newBlock)
            else:
                self.resolve_conflicts(newBlock)


        return True

    # changes data in block and DB by the consensus
    def resolve_conflicts(self, blook):
         while i < 3:
                if self.checkBlock(blook) == 1:
                    self.updateBlock(blook[0], blook[1])
                    i = 3
                else:
                    newBlock = Block(blook[0], blook[2])
                    i += 1
                    print(i)
         return self.currentHash

    #
    def proof_of_work(self, last_block):
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
    #
    def getDbBlocks(self):
        return True


def getCurrentState():
    cursor =connect().cursor()
    cursor.callproc('GetLastBlock')
    answer =list(next(cursor.stored_results()))
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
    check = getCurrentState()
    if check[0] == blockInfo['BlockchainNumber'] and check[1] == blockInfo['Proof']:
        return
    else:
        chain.valid_chain(blockInfo['BlockchainNumber'])


if __name__ == '__main__':
    main()

