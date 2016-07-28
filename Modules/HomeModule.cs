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
    }
  }
}
