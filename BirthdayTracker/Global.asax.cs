using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Dapper; //Used for database access.
using System.Data.SQLite; //Because we're using SQLite
using System.IO; //We need file operations.

namespace BirthdayTracker
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // if database file does not exist
            // read in creation script to db
            // establish connection to db
            // execute query on db
            // if query execution fails
            //      delete the database file
            var db_name = "birthdays.db";
            //allows full path to the db file using ~ which is the root of dir.
            var db_path = Server.MapPath($"~/App_Data/{db_name}");

            if (File.Exists(db_path) == false)
            {
                try
                {
                    
                    var script = Server.MapPath("~/App_Data/db.txt"); //find script
                    var query = File.ReadAllText(script); //converts text into query
                    var connection = $"Data Source={db_path}";  //creates connection string using path dir name 
                    var db = new SQLiteConnection(connection); //connect to database

                    db.Execute(query); //Does everything for Executing Query


                }
                catch (Exception ex)
                {
                    File.Delete(db_path);
                    //don't have a good exception handler for this situation
                    // figure it out later
                    //but still delete db
                }
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}