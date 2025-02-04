﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Windows.Forms;

namespace TUGASPEMVISGAME
{
    internal class Users
    {
        protected const string conString = "server=localhost;database=db_pemvis;uid=root;pwd=;";
        public bool getUser(string usr, string pwd)
        {
            bool result = false;
            MySqlConnection connect = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pengguna WHERE username = @user && password = @pwd");
            cmd.Parameters.AddWithValue("@user", usr);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            try
            {
                connect.Open();
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(connect.State == ConnectionState.Open)
                {
                    connect.Close();
                } 
            }
            return result;
        }
    }
}
