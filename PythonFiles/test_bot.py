import unittest

import scholarly

import Bot
from Bot import Search


class TestBot(unittest.TestCase):
    connection = Bot.connect()
    Search.connection = connection

    def test_addNewArticles(self):
        print("start test_addNewArticles")
        cibitId = "1fCVOhQ"
        articles = dict()
        articles["Test MY DB"] = 15
        articles["test My Db"] = 15
        assert Search().addNewArticles(articles, cibitId) == 15, "fail"
        cursor = self.connection.cursor()
        cursor.callproc("RemoveArticle", ["test my db"])
        self.connection.commit()
        cursor.close()
        print("finish test_addNewArticles Success")

    def test_connect(self):
        print("start test_connect")
        try:
            connection = Bot.connect()
        except Exception as e:
            connection = None
        assert connection is not None, "fail"
        print("finish test_connect Success")

    def test_createDict_success(self):
         print("start test_createDict_success")
         name = "Nadav Voloch, Ben-Gurion University"
         result = 0
         createResult = 0
         try:
            newAuthor = next((scholarly.search_author(name))).fill()
            createResult = Search().createDict(newAuthor)
         except Exception as e:
            print(e)
            result = -1
         assert createResult >= result, "fail"
         print("finish test_createDict_success Success")

    def test_createDict_fail(self):
         print("start test_createDict_fail")
         name = "bla bla bbbbb"
         result = 0
         try:
            newAuthor = next((scholarly.search_author(name))).fill()
            Search().createDict(newAuthor)
         except Exception as e:
            print(e)
            result = -1
         assert result == -1 , "fail"
         print("finish test_createDict_fail Success")

    def test_newUser(self):
        print("start test_newUser")
        cibitId = '4FFeDd'
        cursor = self.connection.cursor()
        cursor.callproc("EmptyUser", [cibitId])
        self.connection.commit()
        Search().newUser(cibitId);
        cursor.callproc('getUser', [cibitId])
        user = list(next(cursor.stored_results())).pop()
        assert user[5] > 0, "fail"
        self.connection.commit()
        cursor.close()
        print("finish test_newUser Success")
