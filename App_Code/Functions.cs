using System;
using System.Data;
using System.Linq;
using System.Web;


namespace Navigation{

    public class Page{
            public Page(string Url, string Title)
            {
                this.Title = Title;
                this.Url = Url;
            }
            public string Title;
            public string Url;
    }

}
/*
namespace Facilities{
    
    public class Room{
        public static Dictionary Types(){
            var types = new Dictionary<string,string>();
            types["lt"] = "Lecture theatre, tiered";
            types["lc"] = "Lecture theatre, circular";
            return types;
        }
    }
    
    public class Park{
        public static Dictionary Parks(){
            var parks = new Dictionary<string,string>();
            parks["w"] = "West";
            parks["c"] = "Central";
            parks["e"] = "East";
            parks["h"] = "Holywell";
            parks["v"] = "Village";
            parks["l"] = "London Campus";
            return parks;
        }
    }
}*/