using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using Dapper;


namespace BirthdayTracker
{
    public static class DatabaseManager
    {
        public static SQLiteConnection GetConnection()
        {
            var db_name = "birthdays.db";
            var db_path = HttpContext.Current.Server.MapPath($"~/App_Data/{db_name}");
            return new SQLiteConnection($"Data Source={db_path}");
            
        }

    }
}