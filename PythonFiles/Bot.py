import mysql.connector
import datetime
import scholarly
import logging
import sys
from CoinGenrator import generateCoin


logger = logging.getLogger('testbot')
hdlr = logging.FileHandler('C:\\Users\\user\\Desktop\\Projects\\FinalProject\CiBit\\testbot.log')
formatter = logging.Formatter('%(asctime)s %(levelname)s %(message)s')
hdlr.setFormatter(formatter)
logger.addHandler(hdlr)
logger.setLevel(logging.WARNING)


# A Class that handles the search we need to do depending on the scenarios.
class Search:
    def __init__(self):
        self.connection = connect()
        self.newPublications = dict()

#   Creates a dictionary to help organize the publications from Google Scholar's database
    def createDict(self,user):
        sum = 0
        for pub in user.publications:
            try:
                if hasattr(pub,'citedby'):
                    self.newPublications[pub.bib['title'].lower()] = pub.citedby
                    sum += pub.citedby
                else:
                    self.newPublications[pub.bib['title'].lower()] = 0
            except KeyError as e:
                sum -= pub.citedby
                logger.info(e)
        return sum

#   Adds all the new articles to the database.
    def addNewArticles(self, articles, cibitId):
        sum = 0
        cursor = self.connection.cursor()
        for key, value in articles.items():
            args = [key, value, cibitId]
            sum += value
            cursor.callproc('CreateArticle', args)
        cursor.close
        return sum

# searches the user for the first time and add all the articles he got to the database and counts all the citations from his aritcles.
    def searchUser(self, author, cibitId):
        check = 0
        newAuthor = next((scholarly.search_author(author))).fill()
        check = self.createDict(newAuthor)
        sum = self.addNewArticles(self.newPublications, cibitId)
        if check == sum:
            print(sum)
        #createCoins(sum, cibitId)

# compare between the two list we got of articles and find what article need to be updated.
    def compareArticles(self, articles, cibitId):
        cursor = self.connection.cursor()
        sum = 0
        for art in articles:
            try:
                count = self.newPublications[art[2]]
                if count > art[3]:
                    cursor.callproc('UpdateCitation', [cibitId, art[1], count-art[3]])
                    sum += (count-art[3])
                del self.newPublications[art[2]]
            except KeyError as e:
                logger.info(e)
        cursor.close()
        return sum

# checks each user for new citations also adds new articles if there is.
    def checkUser(self, user):
        name = user[1] + ' ' + user[2] + ', ' + user[4]
        print("start checking User: " + name)
        newAuthor = next((scholarly.search_author(name))).fill()
        sum = self.createDict(newAuthor)
        newCitations = (sum - user[5]) if user[5] is not None else sum
        print("amount of citations that are not in our database " + str(newCitations))
        if newCitations == 0:
            return 0
        cursor = self.connection.cursor()
        cursor.callproc('getArticles', [user[0]])
        articles = list(next(cursor.stored_results()))
        sum = self.compareArticles(articles, user[0])
        print("added new citations to existing articles " +str(sum))
        if len(self.newPublications) > 0:
            sum += self.addNewArticles(self.newPublications, user[0])
        print("added new citations with new articles " + str(sum))
        newCitations -= sum
        print("amount of of citations left, doubles in Google Scholar " + str(newCitations))
        print("finish checking User:"+ name + "\n")
        if sum != 0:
            self.createCoins(sum, user[0])
        cursor.close()

# Creates a new coin Id and adds it to the database
    def createCoins(self, amount, cibitId):
        i = 0
        worked = False
        while i < amount:
            coinId = generateCoin(cibitId)
            cursor = self.connection.cursor()
            args = [coinId, cibitId, worked]
            result = cursor.callproc('AddCoin', args)
            print(result[-1])
            print(i)
            if result[-1] == 1:
                i += 1
        args = [None, cibitId, None, datetime.datetime.now(), amount]
        cursor.callproc('AddTransaction', args)
        cursor.close()


# a function that gets the new user and find all the details known about him in google scholar
    def newUser(self, cibitId):
        cursor = self.connection.cursor()
        cursor.callproc('getUser', [cibitId])
        user = list(next(cursor.stored_results())).pop()
        name = user[1] + ' ' + user[2] + ', ' + user[4]
        self.searchUser(name, cibitId)

# a function that gets all the users in the database and send each one to check for new citations
    def monthyUpdate(self):
        cursor = self.connection.cursor()
        cursor.callproc('getUsers')
        authors = list(next(cursor.stored_results()))
        for author in authors:
            if self.newPublications is None:
                self.checkUser(author)
            else:
                self.newPublications.clear()
                self.checkUser(author)
        cursor.close()


def connect():
    connection = mysql.connector.connect(host='localhost',
                                         database='cibitdb',
                                         user='bot',
                                         password='qwe32110')
    if connection.is_connected():
        db_Info = connection.get_server_info()
        print("Connected to MySQL Server version ", db_Info)
        cursor = connection.cursor()
        cursor.execute("select database();")
        record = cursor.fetchone()
        print("You're connected to database: ", record)
        cursor.close()
    return connection


def main():
    try:
        search = Search()
        if len(sys.argv) == 2:
            search.newUser(str(sys.argv[1]))
        elif len(sys.argv) == 1:
            search.monthyUpdate()
        else:
            logger.error("Too many arguments")
    except mysql.connector.Error as e:
        print("Error while connecting to MySQL", e)
    finally:
        if search.connection.is_connected():
            search.connection.commit()
            search.connection.close()
            print("MySQL connection is closed")


if __name__ == '__main__':
    main()


#API1 for checking new changes in the last month.
#API2 for recieving a cibit id from the server and updating tables.
#serice with timer - call API1
