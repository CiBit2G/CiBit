import binascii
import hashlib
import json
import os
import sys
import mysql.connector


def generateCoin(cibitId):
    salt = hashlib.sha256(os.urandom(60)).hexdigest().encode('ascii')
    hash = hashlib.pbkdf2_hmac('sha512', cibitId.encode('utf-8'),
                                salt, 100000)
    hash = binascii.hexlify(hash)
    return (salt + hash).decode('ascii')


def verifyCoins(coinId, cibitId):
    salt = coinId[:64]
    coinId = coinId[64:]
    hash = hashlib.pbkdf2_hmac('sha512',
                                  cibitId.encode('utf-8'),
                                  salt.encode('ascii'),
                                  100000)
    hash = binascii.hexlify(hash).decode('ascii')
    return hash == coinId


def createCoins(cibitId, newCoinList, oldCoinList, amount):
        i = 0
        while i < amount:
            coinId = generateCoin(cibitId)
            if coinId not in oldCoinList and coinId not in newCoinList:
                i += 1
                args = (coinId, cibitId)
                newCoinList.append(args)
        return newCoinList


# Creates a new coin list with no duplicate keys in the database and the list.
def arrangeCoins(senderId, amount, cibitId, researchId, connection):
    newCoinList = list()
    cursor = connection.cursor()
    cursor.callproc("getCoins")
    oldCoinList = list(next(cursor.stored_results()))
    result = cursor.callproc('isUserOrBank', [cibitId, 0])
    isUser = result[-1]
    if isUser == 1:
        newCoinList = createCoins(cibitId, newCoinList, oldCoinList, amount)
        createTransaction(senderId, amount, cibitId, researchId, newCoinList, connection)
    else:
        createTransaction(senderId, amount, cibitId, researchId, None, connection)
    cursor.close()


def createTransaction(senderId, amount, cibitId, researchId, newCoinList, connection, oldCoinList=None):
    cursor = connection.cursor()
    transactionList = list()
    transactionId = []
    counter = 0
    fragment = amount
    totalAmount = amount
    while fragment > 0:
        amount = 100 if fragment >= 100 else fragment
        fragment -= amount
        args = [senderId, cibitId, researchId, amount, fragment, counter]
        result = cursor.callproc('AddNewCoinsTransaction', args)
        transactionId.append(result[-1])
    if senderId is not None:
        args2 = [senderId, totalAmount]
        cursor.callproc("getCoinList", args2)
        oldCoinList = list(next(cursor.stored_results()))
    queryCoins = "INSERT INTO coins (coinId, cibitId) VALUES(%s, %s)"
    queryTransactionsCoins = "INSERT INTO coinspertranscation(transactionId, newCoinId, oldCoinId, status) VALUES(%s, %s, %s, %s)"
    cursor.executemany(queryCoins, newCoinList)
    connection.commit()
    for i in range(0, totalAmount):
        args = (transactionId[counter],  None if newCoinList is None else newCoinList[i][0], None if oldCoinList is None else oldCoinList[i][0], 0)
        transactionList.append(args)
        if (i+1) % 100 == 0:
            counter += 1
            cursor.executemany(queryTransactionsCoins, transactionList)
            transactionList.clear()
    cursor.executemany(queryTransactionsCoins, transactionList)
    connection.commit()
    cursor.close()


def connect():
    try:
        connection = mysql.connector.connect(host='localhost',
                                             database='cibitdb',
                                             user='bot',
                                             password='qwe32110',
                                             auth_plugin='mysql_native_password')
        return connection
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)


def main():
    try:
        connection = connect()
        arrangeCoins(sys.argv[1], int(sys.argv[2]), sys.argv[3], None if int(sys.argv[4]) == 0 else int(sys.argv[4]), connection)
    finally:
        if connection is None:
            return 0
        if connection.is_connected():
            connection.commit()
            connection.close()
            print("MySQL connection is closed")


if __name__ == '__main__':
    main()
