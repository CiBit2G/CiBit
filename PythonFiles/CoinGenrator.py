import binascii
import hashlib
import os

def generateCoin(cibitId):
    salt = hashlib.sha256(os.urandom(60)).hexdigest().encode('ascii')
    hash = hashlib.pbkdf2_hmac('sha512', cibitId.encode('utf-8'),
                                salt, 100000)
    hash = binascii.hexlify(hash)
    return (salt + hash).decode('ascii')



def verfiyCoins(coinId, cibitId):
    salt = coinId[:64]
    coinId = coinId[64:]
    hash = hashlib.pbkdf2_hmac('sha512',
                                  cibitId.encode('utf-8'),
                                  salt.encode('ascii'),
                                  100000)
    hash = binascii.hexlify(hash).decode('ascii')
    return hash == coinId



