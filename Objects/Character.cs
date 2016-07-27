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
    private int _bodyTypeId;
    private int _weaponId;
    private int _armorId;
    private int _specialId;

    public Character(string Name, int ClassId, int bodyTypeId, int weaponId, int armorId, int specialId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _classId = ClassId;
      _bodyTypeId = bodyTypeId;
      _weaponId = weaponId;
      _armorId = armorId;
      _specialId = specialId;
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
    public int GetBodyTypeId()
    {
      return _bodyTypeId;
    }
    public void SetBodyType(int BodyTypeId)
    {
      _bodyTypeId = BodyTypeId;
    }
    public int GetWeaponId()
    {
      return _weaponId;
    }
    public void SetWeapon(int WeaponId)
    {
      _weaponId = WeaponId;
    }
    public int GetArmorId()
    {
      return _armorId;
    }
    public void SetArmor(int ArmorId)
    {
      _armorId = ArmorId;
    }
    public int GetSpecialId()
    {
      return _specialId;
    }
    public void SetSpecial(int SpecialId)
    {
      _specialId = SpecialId;
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
        bool bodyTypeIdEquality = this.GetBodyTypeId() == newCharacter.GetBodyTypeId();
        bool weaponIdEquality = this.GetWeaponId() == newCharacter.GetWeaponId();
        bool armorIdEquality = this.GetArmorId() == newCharacter.GetArmorId();
        bool specialIdEquality = this.GetSpecialId() == newCharacter.GetSpecialId();
        return (idEquality && nameEquality && classIdEquality && bodyTypeIdEquality && weaponIdEquality && armorIdEquality && specialIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO characters (name, class_id, bodyType_id, weapon_id, armor_id, specia_id) OUTPUT INSERTED.id VALUES (@CharacterName, @CharacterClassId, @BodyTypeId, @WeaponId, @ArmorId, @SpecialId);", conn);

      SqlParameter characterNameParameter = new SqlParameter();
      characterNameParameter.ParameterName = "@CharacterName";
      characterNameParameter.Value = this.GetName();

      SqlParameter characterClassIdParameter = new SqlParameter();
      characterClassIdParameter.ParameterName = "@CharacterClassId";
      characterClassIdParameter.Value = this.GetClassId();

      SqlParameter bodyTypeIdParameter = new SqlParameter();
      bodyTypeIdParameter.ParameterName = "@BodyTypeId";
      bodyTypeIdParameter.Value = this.GetBodyTypeId();

      SqlParameter weaponIdParameter = new SqlParameter();
      weaponIdParameter.ParameterName = "@WeaponId";
      weaponIdParameter.Value = this.GetWeaponId();

      SqlParameter armorIdParameter = new SqlParameter();
      armorIdParameter.ParameterName = "@ArmorId";
      armorIdParameter.Value = this.GetArmorId();

      SqlParameter specialIdParameter = new SqlParameter();
      specialIdParameter.ParameterName = "@SpecialId";
      specialIdParameter.Value = this.GetSpecialId();

      cmd.Parameters.Add(characterNameParameter);
      cmd.Parameters.Add(characterClassIdParameter);
      cmd.Parameters.Add(bodyTypeIdParameter);
      cmd.Parameters.Add(weaponIdParameter);
      cmd.Parameters.Add(armorIdParameter);
      cmd.Parameters.Add(specialIdParameter);

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
        int bodyTypeId = rdr.GetInt32(3);
        int weaponId = rdr.GetInt32(4);
        int armorId = rdr.GetInt32(5);
        int specialId = rdr.GetInt32(6);
        Character newCharacter = new Character(characterName, characterClassId, bodyTypeId, weaponId, armorId, specialId, characterId);
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
        int foundCharacterClassId = rdr.GetInt32(2);
        int foundBodyTypeId = rdr.GetInt32(3);
        int foundWeaponId = rdr.GetInt32(4);
        int foundArmorId = rdr.GetInt32(5);
        int foundSpecialId = rdr.GetInt32(6);
        foundCharacter = new Character(foundName, foundClassId, foundBodyTypeId, foundWeaponId, foundArmorId, foundSpecialId, foundId);
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

      SqlCommand cmd = new SqlCommand("UPDATE characters SET name = @CharacterName, class_id = @ClassId, bodyType_id = @BodyTypeId, weapon_id = @WeaponId, armor_id = @ArmorId, special_id = @SpecialId OUTPUT INSERTED.name, INSERTED.class_id, INSERTED.bodyType_id, INSERTED.weapon_id, INSERTED.armor_id, INSERTED.special_id INSERTED. WHERE id = @QueryId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CharacterName";
      nameParameter.Value = this.GetName();

      SqlParameter classIdParameter = new SqlParameter();
      classIdParameter.ParameterName = "@CharacterClassId";
      classIdParameter.Value = this.GetClassId();

      SqlParameter bodyTypeIdParameter = new SqlParameter();
      bodyTypeIdParameter.ParameterName = "@BodyTypeId";
      bodyTypeIdParameter.Value = this.GetBodyTypeId();

      SqlParameter weaponIdParameter = new SqlParameter();
      weaponIdParameter.ParameterName = "@WeaponId";
      weaponIdParameter.Value = this.GetWeaponId();

      SqlParameter armorIdParameter = new SqlParameter();
      armorIdParameter.ParameterName = "@ArmorId";
      armorIdParameter.Value = this.GetArmorId();

      SqlParameter specialIdParameter = new SqlParameter();
      specialIdParameter.ParameterName = "@SpecialId";
      specialIdParameter.Value = this.GetSpecialId();

      SqlParameter queryIdParameter = new SqlParameter();
      queryIdParameter.ParameterName = "@QueryId";
      queryIdParameter.Value = this.GetId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(classIdParameter);
      cmd.Parameters.Add(bodyTypeIdParameter);
      cmd.Parameters.Add(weaponIdParameter);
      cmd.Parameters.Add(armorIdParameter);
      cmd.Parameters.Add(specialIdParameter);
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
