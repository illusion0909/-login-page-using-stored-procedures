using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Project3
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if(Page.IsPostBack==false)
            {
                Display_Record();
            }
            //listbox employee data already displayed in  listbox before pressing display button



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insertemp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@eno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ename", TextBox2.Text);
            cmd.Parameters.AddWithValue("@ed",TextBox3.Text);
            cmd.Parameters.AddWithValue("@es", TextBox4.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Clear_Record();
            Display_Record();

        }
        private void Clear_Record()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox1.Focus();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Display_Record();

        }
        private void Display_Record()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dispemp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();
            ListBox1.DataTextField = "ename";
            ListBox1.DataValueField = "eid";
            ListBox1.DataSource = dr;
            ListBox1.DataBind();
            dr.Close();
            cmd.Dispose();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "findEmp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@eno", ListBox1.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TextBox1.Text = dr[0].ToString();
                TextBox2.Text = dr[1].ToString();
                TextBox3.Text = dr[2].ToString();
                TextBox4.Text = dr[3].ToString();
            }
            dr.Close();
            cmd.Dispose();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "updemp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@eno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ename", TextBox2.Text);
            cmd.Parameters.AddWithValue("ed", TextBox3.Text);
            cmd.Parameters.AddWithValue("@es", TextBox4.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Display_Record();
            Clear_Record();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delemp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@eno", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Display_Record();
            Clear_Record();



        }
    }
}