using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CharacterCreator
{
  public class Character
  {
    private int _id;
    private string _name;
    private int _classId;

    public Character(string Name, int ClassId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _classId = ClassId;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string Name)
    {
      _name = Name;
    }

    public int GetClassId()
    {
      return _classId;
    }
    public void SetClass(int ClassId)
    {
      _classId = ClassId;
    }

    public override bool Equals(System.Object otherCharacter)
    {
      if (!(otherCharacter is Character))
      {
        return false;
      }
      else
      {
        Character newCharacter = (Character) otherCharacter;
        bool idEquality = this.GetId() == newCharacter.GetId();
        bool nameEquality = this.GetName() == newCharacter.GetName();
        bool classIdEquality = this.GetClassId() == newCharacter.GetClassId();
        return (idEquality && nameEquality && classIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO characters (name, class_id) OUTPUT INSERTED.id VALUES (@CharacterName, @CharacterClassId);", conn);

      SqlParameter characterNameParameter = new SqlParameter();
      characterNameParameter.ParameterName = "@CharacterName";
      characterNameParameter.Value = this.GetName();

      SqlParameter characterClassIdParameter = new SqlParameter();
      characterClassIdParameter.ParameterName = "@CharacterClassId";
      characterClassIdParameter.Value = this.GetClassId();

      cmd.Parameters.Add(characterNameParameter);
      cmd.Parameters.Add(characterClassIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static List<Character> GetAll()
    {
      List<Character> AllCharacters = new List<Character>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM characters;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int characterId = rdr.GetInt32(0);
        string characterName = rdr.GetString(1);
        int characterClassId = rdr.GetInt32(2);
        Character newCharacter = new Character(characterName, characterClassId, characterId);
        AllCharacters.Add(newCharacter);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllCharacters;
    }

    public static Character Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM characters WHERE id = @CharacterId;", conn);

      SqlParameter characterIdParameter = new SqlParameter();
      characterIdParameter.ParameterName = "@CharacterId";
      characterIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(characterIdParameter);
      rdr = cmd.ExecuteReader();

      Character foundCharacter = null;

      while(rdr.Read())
      {
        int foundId = rdr.GetInt32(0);
        string foundName = rdr.GetString(1);
        int foundClassId = rdr.GetInt32(2);
        foundCharacter = new Character(foundName, foundClassId, foundId);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCharacter;
    }

    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("UPDATE characters SET name = @CharacterName OUTPUT INSERTED.id WHERE id = @QueryId; Update characters SET class_id = @CharacterClassId OUTPUT INSERTED.id WHERE id = @QueryId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CharacterName";
      nameParameter.Value = this.GetName();

      SqlParameter classIdParameter = new SqlParameter();
      classIdParameter.ParameterName = "@CharacterClassId";
      classIdParameter.Value = this.GetClassId();

      SqlParameter queryIdParameter = new SqlParameter();
      queryIdParameter.ParameterName = "@QueryId";
      queryIdParameter.Value = this.GetId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(classIdParameter);
      cmd.Parameters.Add(queryIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void Delete(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM characters WHERE id = @CharacterId;", conn);

      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CharacterId";
      courseIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(courseIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM characters;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
