using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CharacterCreator
{
  public class ClassTest : IDisposable
  {
    public ClassTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=character_creator_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Class.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Class testClass = new Class("Knight");

      testClass.Save();
      List<Class> result = Class.GetAll();
      List<Class> testList = new List<Class>{testClass};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsClassInDatabase()
    {
      Class testClass = new Class("Knight");
      testClass.Save();

      Class foundClass = Class.Find(testClass.GetId());

      Assert.Equal(testClass, foundClass);
    }

    [Fact]
    public void Test_AddItem_AddsItemToClass()
    {
      Item testItem = new Item("Sword", 0, "briefcase.jpg");
      testItem.Save();
      Class testClass = new Class("Knight");
      testClass.Save();

      testClass.AddItem(testItem);

      List<Item> testList = new List<Item>{testItem};
      List<Item> result = testClass.GetItems();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_GetItems_ReturnsAllClassItems()
    {
      Class testClass = new Class("Knight");
      testClass.Save();
      Item testItem1 = new Item("Sword", 0, "briefcase.jpg");
      testItem1.Save();
      Item testItem2 = new Item("Shield", 0, "briefcase.jpg");
      testItem2.Save();

      testClass.AddItem(testItem1);
      testClass.AddItem(testItem2);

      List<Item> testList = new List<Item> {testItem1, testItem2};
      List<Item> result = testClass.GetItems();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Update_UpdatesClassWithNewValues()
    {
      Class testClass = new Class("Knight");
      testClass.Save();

      testClass.SetName("Berserker");
      testClass.Update();

      Class resultClass = Class.Find(testClass.GetId());
      Class test = new Class("Berserker", testClass.GetId());

      Assert.Equal(test, resultClass);
    }

    [Fact]
    public void Test_Delete_DeletesClassFromDatabase()
    {
      Class testClass1 = new Class("Knight");
      testClass1.Save();
      Class testClass2 = new Class("Berserker");
      testClass2.Save();

      Class.Delete(testClass1.GetId());

      List<Class> testList = new List<Class>{testClass2};
      List<Class> resultList = Class.GetAll();

      Assert.Equal(testList, resultList);
    }

    public void Dispose()
    {
      Item.DeleteAll();
      Class.DeleteAll();
    }
  }
}
