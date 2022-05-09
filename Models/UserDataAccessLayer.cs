using PdxUsers.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PdxUsers.Models
{
    public class UserDataAccessLayer
    {
        string connectionString = ConnectionString.userManagementConnectionString;

        public IEnumerable<User> GetAllUser()
        {
            List<User> lstUser = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Mobile = rdr["Mobile"].ToString();
                    user.Role = rdr["Role"].ToString();
                    user.Location = rdr["location"].ToString();
                    user.lastLogin = rdr["lastLogin"].ToString();
                    user.Location = rdr["Location"].ToString();

                    lstUser.Add(user);
                }
                con.Close();
            }
            return lstUser;
        }
        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Mobile", user.Mobile);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Location", user.Location);
                cmd.Parameters.AddWithValue("@lastLogin", user.lastLogin);
               
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Mobile", user.Mobile);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Location", user.Location);
                cmd.Parameters.AddWithValue("@lastLogin", user.lastLogin);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public User GetUserData(int? id)
        {
            User user = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Mobile = rdr["Mobile"].ToString();
                    user.Role = rdr["Role"].ToString();
                    user.Location = rdr["location"].ToString();
                    user.lastLogin = rdr["lastLogin"].ToString();
                    user.Location = rdr["Location"].ToString();
                }
            }
            return user;
        }

        public void DeleteUser(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}