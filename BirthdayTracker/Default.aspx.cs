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
        int index;
        int indexMax;
        DateTime me;
        protected void Page_Load(object sender, EventArgs e)
        {
            var db_name = "birthdays.db";
            var db_path = Server.MapPath($"~/App_Data/{db_name}");
            var db = new SQLiteConnection($"Data Source={db_path}");
            var record = db.QuerySingle("SELECT * FROM birthdays ORDER BY id DESC LIMIT 1");
            indexMax = int.Parse(record.id.ToString());

          
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
            txtDob.Text = record.dob.ToString("yyyy-MM-dd");
            //dob is a DATETIME
            //if you TOSTRING a DATETIME with "d"
            //it becomes the short date format of your computers region
            //for australia, this means dd/mm/yyyy
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            index = int.Parse(lblId.Text);
            try
            {
                var db_name = "birthdays.db";
                var db_path = Server.MapPath($"~/App_Data/{db_name}");
                var db = new SQLiteConnection($"Data Source={db_path}");
                var record = db.QuerySingle($"SELECT * FROM birthdays WHERE id={index}+1 LIMIT 1");

                if (index < indexMax)
                {
                    lblId.Text = record.id.ToString();
                    txtFirst.Text = record.first;
                    txtLast.Text = record.last;
                    txtLikes.Text = record.likes;
                    txtDislikes.Text = record.dislikes;
                    txtDob.Text = record.dob.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception)
            {
                
            }
          
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            var db_name = "birthdays.db";
            var db_path = Server.MapPath($"~/App_Data/{db_name}");
            var db = new SQLiteConnection($"Data Source={db_path}");
            var record = db.QuerySingle("SELECT * FROM birthdays ORDER BY ID DESC LIMIT 1");

            lblId.Text = record.id.ToString();
            txtFirst.Text = record.first;
            txtLast.Text = record.last;
            txtLikes.Text = record.likes;
            txtDislikes.Text = record.dislikes;
            txtDob.Text = record.dob.ToString("yyyy-MM-dd");

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            index = int.Parse(lblId.Text);

            try
            {
                if (index > 1)
                {
                    var db_name = "birthdays.db";
                    var db_path = Server.MapPath($"~/App_Data/{db_name}");
                    var db = new SQLiteConnection($"Data Source={db_path}");
                    var record = db.QuerySingle($"SELECT * FROM birthdays WHERE id={index}-1 LIMIT 1");

                    lblId.Text = record.id.ToString();
                    txtFirst.Text = record.first;
                    txtLast.Text = record.last;
                    txtLikes.Text = record.likes;
                    txtDislikes.Text = record.dislikes;
                    txtDob.Text = record.dob.ToString("yyyy-MM-dd");
                    //txtDob.Text = record.dob.ToString("d");
                }
                if (index == 0)
                {
                    var db = DatabaseManager.GetConnection();
                    var record = db.QuerySingle("SELECT * FROM birthdays LIMIT 1");
                    lblId.Text = record.id.ToString();

                    txtFirst.Text = record.first;
                    txtLast.Text = record.last;
                    txtLikes.Text = record.likes;
                    txtDislikes.Text = record.dislikes;
                    txtDob.Text = record.dob.ToString("d");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var db_name = "birthdays.db";
                var db_path = Server.MapPath($"~/App_Data/{db_name}");
                var db = new SQLiteConnection($"Data Source={db_path}");
                var record = db.ExecuteScalar($"INSERT INTO birthdays (first, last, likes, dislikes, dob) " +
                    $"VALUES ('{txtFirst.Text}', '{txtLast.Text}','{txtLikes.Text}','{txtDislikes.Text}','{txtDob.Text}');");

            }
            catch (Exception)
            {
              
            }
    
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}