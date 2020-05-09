import requests
from CoinGenrator import verifyCoins


class Block:
    def __init__(self, previousHash):
        self.data = list()
        self.Id = 0
        self.previousBlockHash = previousHash
        self.url = "https://localhost:44357/"


    # a function to start building the block's data
    def fillData(self):
        check = self.isBlockReady()
        if check == -1:
            return 0
        self.Id = check
        for i in range(0,100):
            self.getTransactions(i)
        return self.data

    # a function to check if the block has  100 transactions or 24 hours had past since last block.
    def isBlockReady(self):
        temp = self.url+"Transaction/BlockReady/"
        response = requests.get(temp)
        if response.status_code != 200:
            return -1
        return response.json().bcNumber

    # a function to get next transaction of the block from the server.
    def getTransactions(self, index):
        temp = self.url +"Transaction/GetTransaction/"
        Variables = {'BlockchainNumber': self.Id, 'TransactionId': index}
        try:
            response = requests.get(url=temp, params=Variables)
            print(response)
        except requests.exceptions.RequestException as e:
            print(e)
        if response.status_code == 200 and response.json().SenderId is None:
            answer = response.json()
            if self.CheckCoins(answer.CoinList, answer.SenderId):
                self.data.append(answer)
            if self.CheckCoins(answer.CoinList, answer.SenderId):
                self.data.append(answer)
            else:
                return False

    def CheckCoins(self, coinList, cibitId):
        for coin in coinList:
            if not verifyCoins(coin.CoinId, cibitId):
                return False
        return True


def main():
    block = Block(0)
    block.getTransactions(40)

if __name__ == '__main__':
    main()
