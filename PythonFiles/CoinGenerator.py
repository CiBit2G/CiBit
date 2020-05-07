import hashlib
import binascii
import os
from flask import Flask, jsonify, request, app


# Creates a hash for new coinId for the database
@app.route("/api/v1.0/generateCoin" , methods=["GET"])
def generateCoin(cibitId):
    salt = hashlib.sha256(os.urandom(60)).hexdigest().encode('ascii')
    hash = hashlib.pbkdf2_hmac('sha512', cibitId.encode('utf-8'),
                                salt, 100000)
    hash = binascii.hexlify(hash)
    return (salt + hash).decode('ascii')


#  Verify a coinId against the userId
@app.route("/api/v1.0/verfiyCoins" , methods=["GET"])
def verfiyCoins(coinId, cibitId):
    salt = coinId[:64]
    coinId = coinId[64:]
    hash = hashlib.pbkdf2_hmac('sha512',
                                  cibitId.encode('utf-8'),
                                  salt.encode('ascii'),
                                  100000)
    hash = binascii.hexlify(hash).decode('ascii')
    return hash == coinId


# Instantiate the Node
app = Flask(__name__)


if __name__ == '__main__':
    from argparse import ArgumentParser

    parser = ArgumentParser()
    parser.add_argument('-p', '--port', default=5000, type=int, help='port to listen on')
    args = parser.parse_args()
    port = args.port

    app.run(host='0.0.0.0', port=port)
