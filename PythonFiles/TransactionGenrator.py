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


# Creates a new coin list with no duplicate keys in the database and the list.
def createCoins(senderId, amount, cibitId, researchId, connection):
    i = 0
    counter = 0
    fragment = amount
    newCoinList = list()
    cursor = connection.cursor()
    cursor.callproc("getCoins")
    oldCoinList = list(next(cursor.stored_results()))
    while i < amount:
        coinId = generateCoin(cibitId)
        if coinId not in oldCoinList and coinId not in newCoinList:
            counter += 1
            i += 1
            args = (coinId, cibitId)
            newCoinList.append(args)
        if (i + 1) % 100 == 0:
            fragment -= 100
            createTransaction(senderId, 100, cibitId, researchId, newCoinList, fragment, connection)
            oldCoinList += newCoinList
            newCoinList.clear()
    createTransaction(senderId, fragment, cibitId, researchId, newCoinList, 0, connection)
    cursor.close()
    return counter


def createTransaction(senderId, amount, cibitId, researchId, newCoinList, fragment, connection, oldCoinList=None):
    cursor = connection.cursor()
    transactionList = list()
    transactionId = 0
    args = [senderId, cibitId, researchId, amount, fragment, transactionId]
    if senderId is not None:
        args2 = [senderId, amount]
        cursor.callproc("getCoinList", args2)
        oldCoinList = list(next(cursor.stored_results()))
    result = cursor.callproc('AddNewCoinsTransaction', args)
    transactionId = result[-1]
    queryCoins = "INSERT INTO coins (coinId, cibitId) VALUES(%s, %s)"
    queryTransactionsCoins = "INSERT INTO coinspertranscation(transactionId, newCoinId, oldCoinId, status) VALUES(%s, %s, %s, %s)"
    cursor.executemany(queryCoins, newCoinList)
    connection.commit()
    for i in range(0, (amount - 1)):
        args = (transactionId, newCoinList[i][0], None if oldCoinList is None else oldCoinList[i][0], 0)
        transactionList.append(args)
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
        # js = '{ "senderId":"dixRxir-v6AAP", "amount":15, "cibitId":"hf9br7X8F5Qzj", "researchId":10}'
        # data = json.loads(sys.argv[1])
        connection = connect()
        amount = createCoins(sys.argv[1],int(sys.argv[2]), sys.argv[3], int(sys.argv[4]), connection)
        print(amount)
    finally:
        if connection is None:
            return 0
        if connection.is_connected():
            connection.commit()
            connection.close()
            print("MySQL connection is closed")


if __name__ == '__main__':
    main()
