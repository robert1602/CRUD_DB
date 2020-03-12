using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CRUD_DB.Models
{
    public class StudentDBHandle
    {
        private SqlConnection conx;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["StudentConn"].ToString();
            conx = new SqlConnection(constring);
           


            //conx.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["StudentConn"].ConnectionString;
            //conx.ConnectionString = " Server = DESKTOP-CR302AD; Database = StudentDB; Trusted_Connection = True;";

        }

        // **************** ADD NEW STUDENT *********************

        public bool AddStudent(StudentModel oStudentModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", conx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", oStudentModel);
            cmd.Parameters.AddWithValue("Email", oStudentModel);
            cmd.Parameters.AddWithValue("Email", oStudentModel);

            conx.Open();
            int i = cmd.ExecuteNonQuery();
            conx.Close();

            if (i>1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        // ********** VIEW STUDENT DETAILS ********************
        public List<StudentModel> GetStudents()
        {
            connection();
            //string constring = ConfigurationManager.ConnectionStrings["studentconn"].ConnectionString;

            //string constring = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            //conx = new SqlConnection(constring);
            //conx.Open();

            var studentList = new List<StudentModel>();

            SqlCommand cmd = new SqlCommand("GetStudentsDetails",conx);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conx.Open();
            sd.Fill(dt);
            conx.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentList.Add(
                    new StudentModel
                    {
                        IdStudent = Convert.ToInt32(dr["IdStudent"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"])
                    });
            }
            return studentList;
        }

        // ***************** UPDATE STUDENT DETAILS *********************

        public bool UpdateDetails(StudentModel oStudentModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentsDetails", conx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdStudent", oStudentModel);
            cmd.Parameters.AddWithValue("@Name", oStudentModel);
            cmd.Parameters.AddWithValue("@Email", oStudentModel);
            cmd.Parameters.AddWithValue("@Address", oStudentModel);

            conx.Open();
            int i = cmd.ExecuteNonQuery();
            conx.Close();

            if (i >= 1)
                return true;
            else
                return false;

        }

        // ********************** DELETE STUDENT DETAILS *******************

        public bool DeleteStudents(int IdStudent)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", conx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdStudent", IdStudent);

            conx.Open();
            int i = cmd.ExecuteNonQuery();
            conx.Close();

            if (i > 1)
                return true;
            else
                return false; 
  
        }

    }
}