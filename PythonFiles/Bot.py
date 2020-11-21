import logging
import sys

import mysql.connector
import scholarly

from TransactionGenrator import createCoins

logger = logging.getLogger('testbot')
hdlr = logging.FileHandler('C:\\Users\\guybo\\OneDrive\\Documents\\GitHub\\CiBit\\testbot.log')
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
    def createDict(self, user):
        sum = 0
        for pub in user.publications:
            try:
                if hasattr(pub, 'citedby'):
                    self.newPublications[pub.bib['title'].lower()] = pub.citedby
                    sum += pub.citedby
                else:
                    self.newPublications[pub.bib['title'].lower()] = 0
            except KeyError as e:
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
        self.connection.commit()
        cursor.close()
        return sum

    # compare between the two list we got of articles and find what article need to be updated.
    def compareArticles(self, articles, cibitId):
        cursor = self.connection.cursor()
        sum = 0
        for art in articles:
            try:
                count = self.newPublications[art[2]]
                if count > art[3]:
                    cursor.callproc('UpdateCitation', [cibitId, art[1], count - art[3]])
                    sum += (count - art[3])
                del self.newPublications[art[2]]
            except KeyError as e:
                logger.info(e)
        self.connection.commit()
        cursor.close()
        return sum

    # checks each user for new citations also adds new articles if there is.
    def checkUser(self, user):
        name = user[1] + ' ' + user[2] + ', ' + user[4]
        print("start checking User: " + name)
        try:
            newAuthor = next((scholarly.search_author(name))).fill()
        except Exception as e:
            print(e)
            email = user[3].split('@')[1]
            name = user[1] + ' ' + user[2] + ', ' + email
            try:
                newAuthor = next((scholarly.search_author(name))).fill()
            except Exception as e:
                print(e)
                return 0
        sum = self.createDict(newAuthor)
        newCitations = (sum - user[5]) if user[5] is not None else sum
        print("amount of citations that are not in our database " + str(newCitations))
        if newCitations == 0:
            return 0
        cursor = self.connection.cursor()
        cursor.callproc('getArticles', [user[0]])
        articles = list(next(cursor.stored_results()))
        sum = self.compareArticles(articles, user[0])
        print("added new citations to existing articles " + str(sum))
        addSum = 0
        if len(self.newPublications) > 0:
            addSum = self.addNewArticles(self.newPublications, user[0])
            sum += addSum
        print("added new citations with new articles " + str(addSum))
        newCitations -= sum
        print("amount of of citations left, doubles in Google Scholar " + str(newCitations))
        print("finish checking User:" + name + "\n")
        if sum != 0:
            createCoins(None, sum, user[0], None, self.connection)
        cursor.close()

    # searches the user for the first time and add all the articles he got to the database
    # and counts all the citations from his articles.
    def addUser(self, author, cibitId):
        check = 0
        newAuthor = next((scholarly.search_author(author))).fill()
        check = self.createDict(newAuthor)
        sum = self.addNewArticles(self.newPublications, cibitId)
        if check == sum:
            print(sum)
        createCoins(None, sum, cibitId, None, self.connection)

    # a function that gets the new user and find all the details known about him in google scholar
    def newUser(self, cibitId):
        cursor = self.connection.cursor()
        cursor.callproc('getUser', [cibitId])
        user = list(next(cursor.stored_results())).pop()
        name = user[1] + ' ' + user[2] + ', ' + user[4]
        self.addUser(name, cibitId)

    # a function that gets all the users in the database and send each one to check for new citations
    def monthlyUpdate(self):
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


# Creates a steady connection with MySQL DB(cibitdb) so it will stay open till bot finished it's tasks.
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
    search = Search()
    try:
        if len(sys.argv) == 2:
            print(sys.argv[1])
            search.newUser(str(sys.argv[1]))
        elif len(sys.argv) == 1:
            print(sys.argv[0])
            search.monthlyUpdate()
        else:
            logger.error("Too many arguments")
    finally:
        if search is None:
            return 0
        if search.connection.is_connected():
            search.connection.commit()
            search.connection.close()
            print("MySQL connection is closed")


if __name__ == '__main__':
    main()
