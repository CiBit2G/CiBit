import requests
import json
from CoinGenrator import verifyCoins
from NoSSL import no_ssl_verification

url = "https://localhost:5001/"


class Block:
    def __init__(self, id, previousHash):
        self.data = list()
        self.Id = id
        self.previousBlockHash = previousHash
        self.checkBlock()

    # a function to check if the block has  100 transactions or 24 hours had past since last block.
    def checkBlock(self):
        temp = url +"Transaction/BlockInfo"
        payload = {'BlockchainNumber': self.Id}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
            if response.status_code == 200 and response.json() is not None:
                answer = response.json()
                self.fillData(answer['transactionId'], answer['amount'])
            return True
        except requests.exceptions.RequestException as e:
            print(e)
            return False

    # a function to start building the block's data
    def fillData(self, start, amount):
        i = start
        end = amount
        while end > 0:
            if self.getTransactions(i):
                end -= 1
            i += 1


    # a function to get next transaction of the block from the server.
    def getTransactions(self, index):
        temp = url + "Transaction/GetTransaction/"
        payload = {'BlockchainNumber': self.Id,
                   'TransactionId': index}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                if response.status_code == 200:
                    answer = response.json()['transaction']
                    print(answer)
                    checkId = answer['receiverId'] if answer['senderId'] == '' else answer['senderId']
                    if self.CheckCoins(list(answer['coins']), checkId):
                        self.data.append(answer)
                        return True
                return False
        except requests.exceptions.RequestException as e:
            print(e)
            return False

     # a function to check that all the coins of the transaction if they exist and if their hush is right.
    def CheckCoins(self, coinList, cibitId):
        for coin in coinList:
            if not verifyCoins(coin, cibitId):
                return False
            if not self.coinExist(coin):
                return False
        return True

    # a function to check that coin exist in database.
    def coinExist(self, coinId):
        temp = url + "Transaction/CoinExist/"
        payload = {'CoinId': coinId}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                if response.status_code == 200:
                    return True
                return False
        except requests.exceptions.RequestException as e:
            print(e)
            return False

