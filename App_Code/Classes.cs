using System;
using System.Data;
using System.Linq;
using System.Web;
using WebMatrix.Data;
using System.Collections.Generic;
using System.Web.Helpers;

namespace Models{

    public class Request
    {

        public Request(){ }

        public int request_id;
        public string module_code;
        public int booking_round;
        public string priority;
        public string status;
        public int day;
        public string period;
        public string week;
        public int owner;
        public DateTime last_changed;

        public void addData(dynamic data)
        {
            this.request_id = (int) data["request_id"];
            this.module_code = (string) data["module_code"];
            this.booking_round = (int)data["booking_round"];
            this.priority = (string)(data["priority"]);
            this.status = (string)(data["status"]);
            this.day = (int)data["day"];
            this.period = (string)data["period"];
            this.week = (string)data["week"];
            this.owner = (int)data["owner"];
            this.last_changed = (DateTime)data["last_changed"];
        }

        public static List<Request> convertTo(dynamic data){
            List<Request> newData = new List<Request>();
            foreach (WebMatrix.Data.DynamicRecord i in data)
            {
                Request n = new Request();
                n.addData(i);
                newData.Add(n);
            }
            return newData;
        }

        public Dictionary<string,string> ToNiceList() {
            var d = new Dictionary<string, string>();
            d["Module Code"] = module_code;
            try{
                d["Status"] = Bookings.Request.Statuses()[status];
            }catch(Exception e) {
                Console.Write(e);
            }
            d["Day"] = Life.Calendar.Days()[day];
            d["Period(s)"] = period;
            d["Week(s)"] = week;
            d["action"] = "./requests?edit=" + request_id;
            return d;
        }

        public Request(int request_id, string module_code, int booking_round, string priority, string status, int day, string period, string week, int owner, DateTime last_changed)
        {
            this.request_id = request_id;
            this.module_code = module_code;
            this.booking_round = booking_round;
            this.priority = priority;
            this.status = status;
            this.day = day;
            this.period = period;
            this.week = week;
            this.owner = owner;
            this.last_changed = last_changed;
        }
    }

}