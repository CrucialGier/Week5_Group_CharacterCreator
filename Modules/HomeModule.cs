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
        List<Class> AllClasses = Class.GetAll();
        return View["test.cshtml", AllClasses];
      };
    }
  }
}
