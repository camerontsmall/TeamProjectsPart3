using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections.Generic;


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

namespace Facilities{
    
    public class Room{
        public static Dictionary<string,string> Types(){
            var types = new Dictionary<string,string>();
            types["lt"] = "Lecture theatre, tiered";
            types["lf"] = "Lecture theatre, flat";
            types["lc"] = "Lecture theatre, circular";
            types["sf"] = "Seminar room, flat";
            return types;
        }
    }
    
    public class Park{
        public static Dictionary<string,string> Parks(){
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
}