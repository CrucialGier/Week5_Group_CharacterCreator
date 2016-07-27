using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace CharacterCreator
{
  public class Class
  {
    private int _id;
    private string _name;

    public Class(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
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

    public override bool Equals(System.Object otherClass)
    {
      if (!(otherClass is Class))
      {
        return false;
      }
      else
      {
        Class newClass = (Class) otherClass;
        bool idEquality = this.GetId() == newClass.GetId();
        bool nameEquality = this.GetName() == newClass.GetName();
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO classes (name) OUTPUT INSERTED.id VALUES (@ClassName);", conn);

      SqlParameter classNameParameter = new SqlParameter();
      classNameParameter.ParameterName = "@ClassName";
      classNameParameter.Value = this.GetName();

      cmd.Parameters.Add(classNameParameter);

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

    public static List<Class> GetAll()
    {
      List<Class> AllClasses = new List<Class>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM classes;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int classId = rdr.GetInt32(0);
        string className = rdr.GetString(1);
        Class newClass = new Class(className, classId);
        AllClasses.Add(newClass);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllClasses;
    }

    public static Class Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM classes WHERE id = @ClassId;", conn);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@ClassId";
      venueIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(venueIdParameter);
      rdr = cmd.ExecuteReader();

      Class foundClass = null;

      while(rdr.Read())
      {
        int foundId = rdr.GetInt32(0);
        string foundName = rdr.GetString(1);
        foundClass = new Class(foundName, foundId);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundClass;
    }

    public void AddItem(Item newItem)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO classes_items (class_id, item_id) VALUES (@ClassId, @ItemId);", conn);

      SqlParameter itemIdParameter = new SqlParameter();
      itemIdParameter.ParameterName = "@ItemId";
      itemIdParameter.Value = newItem.GetId();

      SqlParameter classIdParameter = new SqlParameter();
      classIdParameter.ParameterName = "@ClassId";
      classIdParameter.Value = this.GetId();

      cmd.Parameters.Add(itemIdParameter);
      cmd.Parameters.Add(classIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Item> GetItems()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT items.* FROM items JOIN classes_items ON(items.id = classes_items.item_id) JOIN classes ON(classes_items.class_id = classes.id) WHERE classes.id = @ClassId;", conn);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@ClassId";
      venueIdParameter.Value = this.GetId();

      cmd.Parameters.Add(venueIdParameter);
      rdr = cmd.ExecuteReader();

      List<Item> allItems = new List<Item> {};

      while (rdr.Read())
      {
        int thisItemId = rdr.GetInt32(0);
        string itemName = rdr.GetString(1);
        int itemTypeId = rdr.GetInt32(2);
        string itemImage = rdr.GetString(3);
        Item foundItem = new Item(itemName, itemTypeId, itemImage, thisItemId);
        allItems.Add(foundItem);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allItems;
    }

    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("UPDATE classes SET name = @ClassName OUTPUT INSERTED.id WHERE id = @QueryId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClassName";
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

      SqlCommand cmd = new SqlCommand("DELETE FROM classes WHERE id = @ClassId;", conn);

      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@ClassId";
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
      SqlCommand cmd = new SqlCommand("DELETE FROM classes;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
