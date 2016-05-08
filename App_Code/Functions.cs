using System;
using System.Data;
using System.Linq;
using System.Web;
using WebMatrix.Data;
using System.Collections.Generic;
using System.Web.Helpers;
using WebMatrix.WebData;

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

namespace Department {

    public class User {

        public static dynamic departmentID() {
            int user_id = WebSecurity.CurrentUserId;
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT dept_id FROM user_department WHERE user_id=@0;", user_id);
            DB.Close();
            if (list.Count() > 0) {
                var first = list.ElementAt(0);
                return first["dept_id"];
            } else {
                return false;
            }
        }
    }

    public class Lecturer {

        public static dynamic lecturerByDept(string dept_id) {

            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT * FROM lecturer WHERE dept_id=@0;", dept_id);
            DB.Close();
            if (list.Count() > 0) {
                return list;
            } else {
                return false;
            }
        }

        public static string lecturerById(int id) {
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT * FROM lecturer WHERE lecturer_id=@0;", id);
            DB.Close();
            if (list.Count() > 0) {
                var one = list.ElementAt(0)["full_name"];
                return one;
            } else {
                return "";
            }

        }
    }
    public class Dept {

        public static Dictionary<string, string> AllDepts() {
            var depts = new Dictionary<string, string>();
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT * FROM dept");
            DB.Close();
            foreach (var item in list) {
                depts.Add(item["dept_id"], item["dept_name"]);
            }
            return depts;
        }
    }
}

namespace Bookings {

    public class Request {
        public static Dictionary<string, string> Statuses() {
            var statuses = new Dictionary<string, string>();
            statuses["c"] = "Confirmed";
            statuses["r"] = "Rejected";
            statuses["p"] = "Pending";
            statuses["w"] = "Withdrawn";
            return statuses;
        }
    }


    public class Module {
        public static Dictionary<string, string> AllCodes(string dept_id = "CO") {
            var modules = new Dictionary<string, string>();
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT * FROM module WHERE dept_id = @0;", dept_id);
            DB.Close();
            foreach (var item in list) {
                modules.Add(item["module_code"], item["module_title"]);
            }
            return modules;
        }
    }

    public class Period {
        public static Dictionary<int, string> All() {
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

/**
Stuff the university has
*/
namespace Facilities {

    public class Room {
        public static Dictionary<string, string> Types() {
            var types = new Dictionary<string, string>();
            types["lt"] = "Lecture theatre, tiered";
            types["lf"] = "Lecture theatre, flat";
            types["lc"] = "Lecture theatre, circular";
            types["sf"] = "Seminar room, flat";
            types["cm"] = "Computer lab, Mac";
            types["cw"] = "Computer lab, Windows";
            types["cd"] = "Computer lab, multiboot";
            return types;
        }

        public static List<string> Codes() {
            List<string> codes = new List<string>();

            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT room_code FROM room;");
            DB.Close();
            foreach (var item in list) {
                codes.Add(item["room_code"]);
            }
            return codes;
        }
    }

    public class Park {
        public static Dictionary<char, string> Parks() {
            var parks = new Dictionary<char, string>();
            parks['w'] = "West";
            parks['c'] = "Central";
            parks['e'] = "East";
            parks['h'] = "Holywell";
            /*
            parks['v'] = "Village";
            parks['l'] = "London Campus"; */
            return parks;
        }
    }

    public class FacilityTypes {
        public static Dictionary<int, string> PossibleFacilities() {
            var facilities = new Dictionary<int, string>();
            var DB = Database.Open("dbConnectionString");
            var list = DB.Query("SELECT * FROM facility");
            DB.Close();
            foreach (var item in list) {
                facilities.Add(item["facility_id"], item["name"]);
            }
            return facilities;
        }
    }
}

/**
Things that happen in life, man
*/

namespace Life {

public class Calendar {

    public static Dictionary<int, string> Days() {
        var days = new Dictionary<int, string>();
        days[1] = "Monday";
        days[2] = "Tuesday";
        days[3] = "Wednesday";
        days[4] = "Thursday";
        days[5] = "Friday";
        days[6] = "Saturday";
        days[7] = "Sunday";
        return days;
    }
}
}