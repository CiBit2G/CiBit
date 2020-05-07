from CoinGenerator import verfiyCoins
import json
import requests
from flask import Flask, jsonify, request


class Block:
    def __init__(self, id, previousHash):
        self.data = list()
        self.Id = id
        self.previousBlockHash = previousHash
        self.url="https://localhost:44357/"


    # a function to start building the block's data
    def fillData(self):

    # a function to check if the block has  100 transactions or 24 hours had past since last block.
    def isBlockReady(self):

    # a function to get next transaction of the block from the server.
    def getTransactions(self, index):
        temp = self.url +"Transaction/GetTransaction"
        index +=1
        Variables = {'BlockchainNumber': self.Id, 'TransactionId': index}
        self.data.append(requests.get(url = temp, params = Variables).json())






@app.route('/transactions/new', methods=['POST'])
def new_transaction():

