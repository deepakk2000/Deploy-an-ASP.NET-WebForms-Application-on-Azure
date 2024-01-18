using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace WebApplication
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            try
            {
                //Server=tcp:deepserver123.database.windows.net,1433;Initial Catalog=feedback;Persist Security Info=False;User ID=deep;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
                //server=deepserver123.database.windows.net;database=fd;trusted_connection=true;
                SqlConnection con = new SqlConnection("Server=tcp:deepserver123.database.windows.net,1433;Initial Catalog=feedback;Persist Security Info=False;User ID=deep;Password=jc@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand("insert into feedback(Fname,Lname,Age,Designation,Feed) values(@fn,@ln,@age,@des,@feed)", con);
                cmd.Parameters.AddWithValue("@fn", TextBox1.Text);
                cmd.Parameters.AddWithValue("@ln", TextBox2.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(TextBox3.Text));
                cmd.Parameters.AddWithValue("@des", TextBox4.Text);
                cmd.Parameters.AddWithValue("@feed", TextBox5.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Feedback submitted ";

            }
            catch (Exception ex)
            {
                Label1.Text = "error" + ex.Message;
            }
        }

    }
}