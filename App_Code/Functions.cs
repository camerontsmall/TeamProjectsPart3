using System;
using System.Data;
using System.Linq;
using System.Web;
using WebMatrix.Data;
using System.Collections.Generic;
using System.Web.Helpers;

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

namespace Bookings{
    
    public class Request{
        public static Dictionary<string,string> Statuses(){
            var statuses = new Dictionary<string, string>();
            statuses["c"] = "Confirmed";
            statuses["r"] = "Rejected";
            statuses["p"] = "Pending";
            statuses["w"] = "Withdrawn";
            return statuses;
        }
}


    public class Module{
        public static Dictionary<string,string> AllCodes(string dept_id = "CO")
        {
            var modules = new Dictionary<string, string>();
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT module_code, module_title FROM module WHERE dept_id LIKE '%" + dept_id + "%';");
            foreach(var item in list)
            {
                modules.Add(item["module_code"], item["module_title"]);
            }
            return modules;
        }
    }

    public class Period
    {
        public static Dictionary<int,string> All()
        {
            var periods = new Dictionary<int, string>();
            periods[1] = "09:00-10:00";
            periods[2] = "10:00-11:00";
            periods[3] = "11:00-12:00";
            periods[4] = "12:00-13:00";
            periods[5] = "13:00-14:00";
            periods[6] = "14:00-15:00";
            periods[7] = "15:00-16:00";
            periods[8] = "16:00-17:00";
            periods[9] = "17:00-18:00";
            periods[10] = "18:00-19:00";
            periods[11] = "19:00-20:00";
            periods[12] = "20:00-21:00";
            periods[13] = "21:00-22:00";
            periods[14] = "22:00-23:00";
            periods[15] = "23:00-24:00";
            return periods;
        }
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
            types["cm"] = "Computer lab, Mac";
            types["cw"] = "Computer lab, Windows";
            types["cd"] = "Computer lab, multiboot";
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