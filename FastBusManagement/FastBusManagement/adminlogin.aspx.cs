﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastBusManagement
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string connectionString = "Data Source=DESKTOP-384I4IC\\SQLEXPRESS;Initial Catalog=BusManagement;Integrated Security=True";
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("select * from Admin where Username = '" + TextBox1.Text.Trim() + "' AND Password = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                SetValueForText1 = TextBox1.Text.Trim();
                SetValueForText2 = TextBox2.Text.Trim();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Successful login');</script>");
                    }
                    Response.Redirect("adminmain.aspx");
                    //Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }
    }
}