using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Project3
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if(cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private int CheckUser(string un, string up)
        {
            SqlCommand cmd = new SqlCommand("LoginCheck", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", un);
            cmd.Parameters.AddWithValue("@up", up);
            SqlParameter ret=new SqlParameter("@ret",SqlDbType.Int);
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);
            cmd.ExecuteNonQuery();
            int d = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            cmd.Dispose();
            return d;



        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            int k = CheckUser(TextBox1.Text, TextBox2.Text);
            if (k == -1)
            {
                Label1.Text = "Wrong UserName";
            }
            if (k == -2)
            {
                Label1.Text = "Wrong Password";
            }
            if (k == 1)
            {
                Label1.Text = "Welcome";

            }
        }
    }
}