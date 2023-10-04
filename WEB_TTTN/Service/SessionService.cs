﻿using DataTTTN.Models;
using Newtonsoft.Json;

namespace WEB_TTTN.Service
{
    public class SessionService
    {
        public static void SetObjToJson(ISession session, string key, object value)
        {

            var jsonString = JsonConvert.SerializeObject(value);

            session.SetString(key, jsonString);

        }
        public static List<Product> GetObjFromSession(ISession session, string key)
        {

            var data = session.GetString(key);
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<Product>>(data);
                return listObj;
            }
            else return new List<Product>();
        }
        public static User GetUserFromSession(ISession session, string key)
        {
            var data = session.GetString(key);
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<User>(data);
                return listObj;
            }
            else return new User();
        }
    }
}
