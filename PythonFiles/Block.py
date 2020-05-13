import requests
import json
import hashlib
from CoinGenrator import verifyCoins
from NoSSL import no_ssl_verification

url = "https://localhost:44357/"


class Block:
    def __init__(self, id, previousHash):
        self.data = list()
        self.Id = id
        self.previousBlockHash = previousHash
        self.hush is None
        self.checkBlock()


    # a function to check if the block has  100 transactions or 24 hours had past since last block.
    def checkBlock(self):
        temp = url +"Transaction/BlockInfo"
        payload = {'BlockchainNumber': self.Id}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)
        if response.status_code == 200:
            answer = response.json()
            self.fillData(answer['transactionId'], answer['amount'] + answer['transactionId'])
        return True

    # a function to start building the block's data
    def fillData(self, start, end):
        for i in range(start, end):
            self.getTransactions(i)

    # a function to get next transaction of the block from the server.
    def getTransactions(self, index):
        temp = url + "Transaction/GetTransaction/"
        payload = {'BlockchainNumber': self.Id,
                   'TransactionId': index}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)
        if response.status_code == 200:
            answer = response.json()['transaction']
            print(answer)
            checkId = answer['receiverId'] if answer['senderId'] == '' else answer['senderId']
            if self.CheckCoins(list(answer['coins']), checkId):
                self.data.append(answer)

    def CheckCoins(self, coinList, cibitId):
        for coin in coinList:
            if not verifyCoins(coin, cibitId):
                return False
            if not self.coinExist(coin):
                return False
        return True

    def coinExist(self, coinId):
        temp = url + "Transaction/CoinExist/"
        payload = {'CoinId': coinId}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
        except requests.exceptions.RequestException as e:
            print(e)
            return False
        if response.status_code == 200:
            return True
        return False

    def Hash(self):
        block_string = json.dumps(self).encode()
        self.hush = hashlib.sha256(block_string).hexdigest()


