using System.Collections.Generic;
using System.Data.SqlClient;
using System;


namespace CharacterCreator
{
  public class Item
  {
    private int _id;
    private string _name;
    private int _typeId;
    private string _image;

    public Item(string Name,  int TypeId, string image, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _typeId = TypeId;
      _image = image;
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
    public string GetImage()
    {
      return _image;
    }
    public void SetImage(string Image)
    {
      _image = Image;
    }

    public int GetTypeId()
    {
      return _typeId;
    }
    public void SetTypeId(int TypeId)
    {
      _typeId = TypeId;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = this.GetId() == newItem.GetId();
        bool nameEquality = this.GetName() == newItem.GetName();
        bool typeIdEquality = this.GetTypeId() == newItem.GetTypeId();
        bool imageEquality = this.GetImage() == newItem.GetImage();
        return (idEquality && nameEquality && typeIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO items (name, type_id, image) OUTPUT INSERTED.id VALUES (@ItemName, @ItemTypeId, @ItemImage);", conn);

      SqlParameter itemNameParameter = new SqlParameter();
      itemNameParameter.ParameterName = "@ItemName";
      itemNameParameter.Value = this.GetName();

      SqlParameter typeIdParameter = new SqlParameter();
      typeIdParameter.ParameterName = "@ItemTypeId";
      typeIdParameter.Value = this.GetTypeId();

      SqlParameter imageParameter = new SqlParameter();
      imageParameter.ParameterName = "@ItemImage";
      imageParameter.Value = this.GetImage();

      cmd.Parameters.Add(typeIdParameter);
      cmd.Parameters.Add(itemNameParameter);
      cmd.Parameters.Add(imageParameter);

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

    public static List<Item> GetAll()
    {
      List<Item> AllItems = new List<Item>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM items;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemName = rdr.GetString(1);
        int itemTypeId = rdr.GetInt32(2);
        string itemImage = rdr.GetString(3);
        Item newItem = new Item(itemName, itemTypeId, itemImage, itemId);
        AllItems.Add(newItem);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllItems;
    }

    public static Item Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE id = @ItemId;", conn);

      SqlParameter itemIdParameter = new SqlParameter();
      itemIdParameter.ParameterName = "@ItemId";
      itemIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(itemIdParameter);
      rdr = cmd.ExecuteReader();

      Item foundItem = null;

      while(rdr.Read())
      {
        int foundId = rdr.GetInt32(0);
        string foundName = rdr.GetString(1);
        int foundTypeId = rdr.GetInt32(2);
        string foundImage = rdr.GetString(3);
        foundItem = new Item(foundName, foundTypeId, foundImage, foundId);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundItem;
    }

    public void AddClass(Class newClass)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO classes_items (class_id, item_id) VALUES (@ClassId, @ItemId);", conn);

      SqlParameter classIdParameter = new SqlParameter();
      classIdParameter.ParameterName = "@ClassId";
      classIdParameter.Value = newClass.GetId();

      SqlParameter itemIdParameter = new SqlParameter();
      itemIdParameter.ParameterName = "@ItemId";
      itemIdParameter.Value = this.GetId();

      cmd.Parameters.Add(classIdParameter);
      cmd.Parameters.Add(itemIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Class> GetClasses()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT classes.* FROM classes JOIN classes_items ON(classes.id = classes_items.class_id) JOIN items ON(classes_items.item_id = items.id) WHERE items.id = @ItemId;", conn);

      SqlParameter itemIdParameter = new SqlParameter();
      itemIdParameter.ParameterName = "@ItemId";
      itemIdParameter.Value = this.GetId();

      cmd.Parameters.Add(itemIdParameter);
      rdr = cmd.ExecuteReader();

      List<Class> allClasses = new List<Class> {};

      while (rdr.Read())
      {
        int thisClassId = rdr.GetInt32(0);
        string className = rdr.GetString(1);
        Class foundClass = new Class(className, thisClassId);
        allClasses.Add(foundClass);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allClasses;
    }

    public void Update()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("UPDATE items SET name = @ItemName OUTPUT INSERTED.id WHERE id = @QueryId; UPDATE items SET type_id = @ItemTypeId OUTPUT INSERTED.id WHERE id = @QueryId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ItemName";
      nameParameter.Value = this.GetName();

      SqlParameter typeIdParameter = new SqlParameter();
      typeIdParameter.ParameterName = "@ItemTypeId";
      typeIdParameter.Value = this.GetTypeId();

      SqlParameter imageParameter = new SqlParameter();
      imageParameter.ParameterName = "@ItemImage";
      imageParameter.Value = this.GetImage();

      SqlParameter queryIdParameter = new SqlParameter();
      queryIdParameter.ParameterName = "@QueryId";
      queryIdParameter.Value = this.GetId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(typeIdParameter);
      cmd.Parameters.Add(imageParameter);
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

      SqlCommand cmd = new SqlCommand("DELETE FROM items WHERE id = @ItemId;", conn);

      SqlParameter itemIdParameter = new SqlParameter();
      itemIdParameter.ParameterName = "@ItemId";
      itemIdParameter.Value = Id.ToString();

      cmd.Parameters.Add(itemIdParameter);
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
      SqlCommand cmd = new SqlCommand("DELETE FROM items;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
