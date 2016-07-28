using System.Collections.Generic;
using System;
using Nancy;

namespace CharacterCreator
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ =>{
        return View["index.cshtml"];
      };
      Get["/character/new"]= _ =>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("class", Class.GetAll());
        model.Add("item", Item.GetAll());
        model.Add("itemTypes", ItemType.GetAll());
        return View["test.cshtml", model];
      };
      Post["/character/create"]= _ =>{
        Character newCharacter = new Character(Request.Form["name"],Request.Form["klass"],Request.Form["bodyType"],Request.Form["weapon"],Request.Form["armor"],Request.Form["special"]);
        newCharacter.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        Class characterClassName = Class.Find(newCharacter.GetClassId());
        Item characterBodyType = Item.Find(newCharacter.GetBodyTypeId());
        Item characterWeapon = Item.Find(newCharacter.GetWeaponId());
        Item characterArmor = Item.Find(newCharacter.GetArmorId());
        Item characterSpecial = Item.Find(newCharacter.GetSpecialId());
        model.Add("className", characterClassName);
        model.Add("bodyType", characterBodyType);
        model.Add("weapon", characterWeapon);
        model.Add("armor", characterArmor);
        model.Add("special", characterSpecial);
        model.Add("newCharacter", newCharacter);
        return View["new_character.cshtml", model];
      };
      Get["/character/load"] =_=> {
        List<Character> AllCharacters = Character.GetAll();
        return View["load_character.cshtml", AllCharacters];
      };
      Get["/character/update/{id}"] =parameters=> {
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("klass", Class.GetAll());
        model.Add("item", Item.GetAll());
        model.Add("itemTypes", ItemType.GetAll());
        Character currentCharacter = Character.Find(parameters.id);
        model.Add("current", currentCharacter);
        return View["update_character.cshtml", model];
      };
      Post["/character/confirm-update/{id}"] =parameters=> {
        Character currentCharacter = Character.Find(parameters.id);
        currentCharacter.SetBodyType(Request.Form["bodyType"]);
        currentCharacter.SetClass(Request.Form["klass"]);
        currentCharacter.SetName(Request.Form["name"]);
        currentCharacter.SetWeapon(Request.Form["weapon"]);
        currentCharacter.SetArmor(Request.Form["armor"]);
        currentCharacter.SetSpecial(Request.Form["special"]);
        currentCharacter.Update();
        List<Character> AllCharacters = Character.GetAll();
        return View["load_character.cshtml", AllCharacters];
      };
      Get["/character/delete/{id}"] =parameters=> {
        Character currentCharacter = Character.Find(parameters.id);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Class characterClassName = Class.Find(currentCharacter.GetClassId());
        Item characterBodyType = Item.Find(currentCharacter.GetBodyTypeId());
        Item characterWeapon = Item.Find(currentCharacter.GetWeaponId());
        Item characterArmor = Item.Find(currentCharacter.GetArmorId());
        Item characterSpecial = Item.Find(currentCharacter.GetSpecialId());
        model.Add("current", currentCharacter);
        model.Add("className", characterClassName);
        model.Add("bodyType", characterBodyType);
        model.Add("weapon", characterWeapon);
        model.Add("armor", characterArmor);
        model.Add("special", characterSpecial);
        return View["delete_character.cshtml", model];
      };
      Get["/character/delete-confirm/{id}"] =parameters=> {
        Character.Delete(parameters.id);
        List<Character> AllCharacters = Character.GetAll();
        return View["load_character.cshtml", AllCharacters];
      };
    }
  }
}
