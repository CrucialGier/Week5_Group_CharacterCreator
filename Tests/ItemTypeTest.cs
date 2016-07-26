using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CharacterCreator
{
  public class ItemTypeTest : IDisposable
  {
    public ItemTypeTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=character_creator_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = ItemType.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      ItemType testItemType = new ItemType("Artorias");

      testItemType.Save();
      List<ItemType> result = ItemType.GetAll();
      List<ItemType> testList = new List<ItemType>{testItemType};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsItemTypeInDatabase()
    {
      ItemType testItemType = new ItemType("Artorias");
      testItemType.Save();

      ItemType foundItemType = ItemType.Find(testItemType.GetId());

      Assert.Equal(testItemType, foundItemType);
    }

    [Fact]
    public void Test_Update_UpdatesItemTypeWithNewValues()
    {
      ItemType testItemType = new ItemType("Artorias");
      testItemType.Save();

      testItemType.SetName("Guts");
      testItemType.Update();

      ItemType resultItemType = ItemType.Find(testItemType.GetId());
      ItemType test = new ItemType("Guts", testItemType.GetId());

      Assert.Equal(test, resultItemType);
    }

    [Fact]
    public void Test_Delete_DeletesItemTypeFromDatabase()
    {
      ItemType testItemType1 = new ItemType("Artorias");
      testItemType1.Save();
      ItemType testItemType2 = new ItemType("Guts");
      testItemType2.Save();

      ItemType.Delete(testItemType1.GetId());

      List<ItemType> testList = new List<ItemType>{testItemType2};
      List<ItemType> resultList = ItemType.GetAll();

      Assert.Equal(testList, resultList);
    }

    public void Dispose()
    {
      ItemType.DeleteAll();
    }
  }
}
