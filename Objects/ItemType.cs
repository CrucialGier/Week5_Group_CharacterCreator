using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CharacterCreator
{
  public class ItemType
  {
    private int _id;
    private string _name;
    public ItemType(string name, int id = 0)
    {
      _id = id;
      _name = name;
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

    public override bool Equals(System.Object otherItemType)
    {
      if (!(otherItemType is ItemType))
      {
        return false;
      }
      else
      {
        ItemType newItemType = (ItemType) otherItemType;
        bool idEquality = this.GetId() == newItemType.GetId();
        bool nameEquality = this.GetName() == newItemType.GetName();
        return (idEquality && nameEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO itemtypes (name) OUTPUT INSERTED.id VALUES (@ItemTypeName);", conn);

      SqlParameter itemTypeNameParameter = new SqlParameter();
      itemTypeNameParameter.ParameterName = "@ItemTypeName";
      itemTypeNameParameter.Value = this.GetName();

      cmd.Parameters.Add(itemTypeNameParameter);

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
    public static List<ItemType> GetAll()
    {
      List<ItemType> AllItemTypes = new List<ItemType>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM itemtypes;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int itemTypeId = rdr.GetInt32(0);
        string itemTypeName = rdr.GetString(1);
        ItemType newItemType = new ItemType(itemTypeName, classId);
        AllItemTypes.Add(newItemType);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllItemTypes;
    }
    public static ItemType Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM itetypes WHERE id = @ItemTypeId;", conn);

      SqlParameter itemTypeIdParameter = new SqlParameter();
      itemTypeIdParameter.ParameterName = "@ItemTypeId";
      itemTypeIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(itemTypeIdParameter);
      rdr = cmd.ExecuteReader();

      ItemType foundItemType = null;

      while(rdr.Read())
      {
        int foundId = rdr.GetInt32(0);
        string foundName = rdr.GetString(1);
        foundItemType = new ItemType(foundName, foundId);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundItemType;
    }
    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("UPDATE itemtypes SET name = @ItemTypeName OUTPUT INSERTED.id WHERE id = @QueryId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ItemTypeName";
      nameParameter.Value = this.GetName();

      SqlParameter queryIdParameter = new SqlParameter();
      queryIdParameter.ParameterName = "@QueryId";
      queryIdParameter.Value = this.GetId();

      cmd.Parameters.Add(nameParameter);
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

      SqlCommand cmd = new SqlCommand("DELETE FROM itemtypes WHERE id = @ItemTypeId;", conn);

      SqlParameter itemTypeIdParameter = new SqlParameter();
      itemTypeIdParameter.ParameterName = "@ItemTypeId";
      itemTypeIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(itemTypeIdParameter);
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
      SqlCommand cmd = new SqlCommand("DELETE FROM itemtypes;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
