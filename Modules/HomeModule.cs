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
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("class", Class.GetAll());
        model.Add("item", Item.GetAll());
        model.Add("itemTypes", ItemType.GetAll());
        return View["new_character.cshtml", model];
      };
    }
  }
}
