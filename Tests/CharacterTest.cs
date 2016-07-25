using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CharacterCreator
{
  public class CharacterTest : IDisposable
  {
    public CharacterTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=character_creator_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Character.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Character testCharacter = new Character("Artorias", 0);

      testCharacter.Save();
      List<Character> result = Character.GetAll();
      List<Character> testList = new List<Character>{testCharacter};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsCharacterInDatabase()
    {
      Character testCharacter = new Character("Artorias", 0);
      testCharacter.Save();

      Character foundCharacter = Character.Find(testCharacter.GetId());

      Assert.Equal(testCharacter, foundCharacter);
    }

    [Fact]
    public void Test_Update_UpdatesCharacterWithNewValues()
    {
      Character testCharacter = new Character("Artorias", 0);
      testCharacter.Save();

      testCharacter.SetName("Guts");
      testCharacter.Update();

      Character resultCharacter = Character.Find(testCharacter.GetId());
      Character test = new Character("Guts", 0, testCharacter.GetId());

      Assert.Equal(test, resultCharacter);
    }

    [Fact]
    public void Test_Delete_DeletesCharacterFromDatabase()
    {
      Character testCharacter1 = new Character("Artorias", 0);
      testCharacter1.Save();
      Character testCharacter2 = new Character("Guts", 0);
      testCharacter2.Save();

      Character.Delete(testCharacter1.GetId());

      List<Character> testList = new List<Character>{testCharacter2};
      List<Character> resultList = Character.GetAll();

      Assert.Equal(testList, resultList);
    }

    public void Dispose()
    {
      Character.DeleteAll();
    }
  }
}
