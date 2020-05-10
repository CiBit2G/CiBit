import requests
import json
from CoinGenrator import verifyCoins
from NoSSL import no_ssl_verification


class Block:
    def __init__(self, previousHash):
        self.data = list()
        self.Id = 0
        self.previousBlockHash = previousHash
        self.url = "https://localhost:44357/"

    # a function to check if the block has  100 transactions or 24 hours had past since last block.
    def isBlockReady(self):
        temp = self.url + "Transaction/BlockReady/"
        payload = {}
        headers = {}
        with no_ssl_verification():
            response = requests.request("GET", url=temp, headers=headers, data=payload)
        if response.status_code != 200:
            return -1
        return response.json()

    # a function to start building the block's data
    def fillData(self, start, end):
        for i in range(start, end):
            self.getTransactions(i)

    # a function to get next transaction of the block from the server.
    def getTransactions(self, index):
        temp = self.url + "Transaction/GetTransaction/"
        payload = {'BlockchainNumber': self.Id,
                   'TransactionId': index}
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=json.dumps(payload))
                print(response.text.encode('utf8'))
        except requests.exceptions.RequestException as e:
            print(e)
        if response.status_code == 200:
            answer = response.json()['transaction']
            print(answer)
            checkId = answer['receiverId'] if answer['senderId'] is None else answer['senderId']
            if self.CheckCoins(answer['coins'], checkId):
                self.data.append(answer)

    def CheckCoins(self, coinList, cibitId):
        for coin in coinList:
            if not verifyCoins(coin, cibitId):
                return False
            if not self.coinExist(self, coin):
                return False
        return True

    def coinExist(self, coinId):
        temp = self.url +"Transaction/CoinExist/"
        payload = "{\"CoinId\":" + coinId + "\n}"
        headers = {'Content-Type': 'application/json'}
        try:
            with no_ssl_verification():
                response = requests.request('GET', url=temp, headers=headers, data=payload)
            print(response)
        except requests.exceptions.RequestException as e:
            print(e)
            return False
        if response.status_code == 200:
            return True
        return False


def main():
    block = Block(0)
    startInfo = block.isBlockReady()
    print(startInfo)
    block.fillData(startInfo['transactionId'], (startInfo['transactionId'] + startInfo['amount']))
    for b in block.data:
        print(b)


if __name__ == '__main__':
    main()
