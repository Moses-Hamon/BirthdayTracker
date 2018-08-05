using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using System.Data.SQLite;

namespace BirthdayTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            //var db_name = "birthdays.db";
            //var db_path = Server.MapPath($"~/App_Data/{db_name}");
            //var db = new SQLiteConnection($"Data Source={db_path}");
            var db = DatabaseManager.GetConnection();
            var record = db.QuerySingle("SELECT * FROM birthdays LIMIT 1");
            lblId.Text = record.id.ToString();
            //the id property will be of type LONG
            //LONG is a 64bit INT
            //INT is not STRING
            //therefore: .ToString();
            txtFirst.Text = record.first;
            txtLast.Text = record.last;
            txtLikes.Text = record.likes;
            txtDislikes.Text = record.dislikes;
            txtDob.Text = record.dob.ToString("d");
            //dob is a DATETIME
            //if you TOSTRING a DATETIME with "d"
            //it becomes the short date format of your computers region
            //for australia, this means dd/mm/yyyy
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var db_name = "birthdays.db";
            var db_path = Server.MapPath($"~/App_Data/{db_name}");
            var db = new SQLiteConnection($"Data Source={db_path}");
            var record = db.QuerySingle("SELECT * FROM birthdays ORDER BY DESC LIMIT 1");

            txtFirst.Text = record.first;
            txtLast.Text = record.last;
            txtLikes.Text = record.likes;
            txtDislikes.Text = record.dislikes;
            txtDob.Text = record.dob.ToString("d");
        }
    }
}