using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CharacterCreator
{
  public class ItemTest : IDisposable
  {
    public ItemTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=character_creator_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Item.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Item testItem = new Item("sword", 0, "briefcase.jpg");

      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsItemInDatabase()
    {
      Item testItem = new Item("sword", 0, "briefcase.jpg");
      testItem.Save();

      Item foundItem = Item.Find(testItem.GetId());

      Assert.Equal(testItem, foundItem);
    }

    [Fact]
    public void Test_Update_UpdatesItemWithNewValues()
    {
      Item testItem = new Item("sword", 0, "briefcase.jpg");
      testItem.Save();

      testItem.SetName("armor");
      testItem.Update();

      Item resultItem = Item.Find(testItem.GetId());
      Item test = new Item("armor", 0, "briefcase.jpg", testItem.GetId());

      Assert.Equal(test, resultItem);
    }

    [Fact]
    public void Test_Delete_DeletesItemFromDatabase()
    {
      Item testItem1 = new Item("sword", 0, "briefcase.jpg");
      testItem1.Save();
      Item testItem2 = new Item("shield", 0, "briefcase.jpg");
      testItem2.Save();

      Item.Delete(testItem1.GetId());

      List<Item> testList = new List<Item>{testItem2};
      List<Item> resultList = Item.GetAll();

      Assert.Equal(testList, resultList);
    }

    [Fact]
    public void Test_AddClass_AddsClassToItem()
    {

      Class testClass = new Class("Knight");
      testClass.Save();
      Item testItem = new Item("Sword", 0, "briefcase.jpg");
      testItem.Save();

      testItem.AddClass(testClass);

      List<Class> testList = new List<Class>{testClass};
      List<Class> result = testItem.GetClasses();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_GetClasses_ReturnsAllItemsClasses()
    {
      Item testItem = new Item("sword", 0, "briefcase.jpg");
      testItem.Save();
      Class testClass1 = new Class("Knight");
      testClass1.Save();
      Class testClass2 = new Class("Berserker");
      testClass2.Save();

      testItem.AddClass(testClass1);
      testItem.AddClass(testClass2);

      List<Class> testList = new List<Class> {testClass1, testClass2};
      List<Class> result = testItem.GetClasses();

      Assert.Equal(testList, result);
    }
    public void Dispose()
    {
      Class.DeleteAll();
      Item.DeleteAll();
    }
  }
}
