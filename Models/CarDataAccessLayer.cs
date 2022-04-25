using StudentM.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudentM.Models
{
    public class CarDataAccessLayer
    {

            string connectionString = ConnectionString.carManagementConnectionString;

            public IEnumerable<Car> GetAllCar()
            {
                List<Car> lstCar = new List<Car>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Car car = new Car();
                        car.Id = Convert.ToInt32(rdr["Id"]);
                        car.Brand = rdr["Brand"].ToString();
                        car.Model = rdr["Model"].ToString();
                        car.Number= rdr["Number"].ToString();
                        car.TopSpeed = rdr["TopSpeed"].ToString();
                      

                        lstCar.Add(car);
                    }
                    con.Close();
                }
                return lstCar;
            }
            public void AddCar(Car car)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCar", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Brand", car.Brand);
                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Number", car.Number);
                    cmd.Parameters.AddWithValue("@TopSpeed", car.TopSpeed);
                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            public void UpdateCar(Car car)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCar", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", car.Id);
                    cmd.Parameters.AddWithValue("@Brand", car.Brand);
                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Nummber", car.Number);
                    cmd.Parameters.AddWithValue("@TopSpeed", car.TopSpeed);
                  
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            public Car GetCarData(int? id)
            {
                Car car = new Car();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Car WHERE Id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        car.Id = Convert.ToInt32(rdr["Id"]);
                        car.Brand = rdr["Brand"].ToString();
                        car.Model = rdr["Model"].ToString();
                        car.Number = rdr["Number"].ToString();
                        car.TopSpeed = rdr["TopSpeed"].ToString();
                      
                    }
                }
                return car;
            }

            public void DeleteCar(int? id)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteCar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }