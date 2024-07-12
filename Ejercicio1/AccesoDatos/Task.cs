using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ejercicio1.AccesoDatos
{

  


    public class Task
    {
        private string connString = ConfigurationManager.AppSettings["SQLCONECCION"];

        public List<Models.Task> TaskList()
        {
            List<Models.Task> listTask = new List<Models.Task>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaskList", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow fila in dt.Rows)
                            {
                                Models.Task task = new Models.Task();
                                task.Id = Convert.ToInt32(fila["Id"]);
                                task.Title = fila["Title"].ToString();
                                task.Description = fila["Description"].ToString();
                                task.IsCompleted = Convert.ToInt32(fila["IsCompleted"]);
                                task.IsCompletedName = fila["IsCompletedName"].ToString();

                                listTask.Add(task);
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            

            return listTask;
        }


        public Models.Task TaskIngresa(Models.Task task)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaskIngresa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Title", task.Title));
                        cmd.Parameters.Add(new SqlParameter("@Description", task.Description));
                        cmd.Parameters.Add(new SqlParameter("@IsCompleted", task.IsCompleted));
                        cmd.ExecuteNonQuery();
                    }
                }



                return task;
            }
            catch (SqlException)
            {
                throw;
            }
        }



        public Models.Task TaskActualiza(Models.Task task)
        {


            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaskActualiza", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Id", task.Id));
                        cmd.Parameters.Add(new SqlParameter("@Title", task.Title));
                        cmd.Parameters.Add(new SqlParameter("@Description", task.Description));
                        cmd.Parameters.Add(new SqlParameter("@IsCompleted", task.IsCompleted));

                        //if (task.IsCompleted == true)
                        //{
                        //    cmd.Parameters.Add(new SqlParameter("@IsCompleted", 1));

                        //}
                        //else
                        //{
                        //cmd.Parameters.Add(new SqlParameter("@IsCompleted", 0));

                        //}
                        cmd.ExecuteNonQuery();
                    }
                }



                return task;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }


        public Models.Task TaskElimina(Models.Task task)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaskElimina", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Id", task.Id));
                        cmd.ExecuteNonQuery();
                    }
                }



                return task;
            }
            catch (SqlException)
            {
                throw;
            }
        }


        public Models.Task TaskRetornaTareas(Models.Task  e_task)
        {
            Models.Task task = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaskRetornaTareas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Id", e_task.Id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                task = new Models.Task
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    IsCompleted = Convert.ToInt32(reader["IsCompleted"]),

                                };
                            }
                        }
                    }
                }


                return task;

            }
            catch (SqlException ex)
            {
                throw;
            }
            

        }



    }


}




