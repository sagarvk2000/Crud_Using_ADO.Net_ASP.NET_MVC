using System.Data.SqlClient;

namespace Crud_Using_ADO.Net.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public StudentCrud(IConfiguration configuration)
        {
            this.configuration=configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();
            string qry = " select * from Student where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student stu = new Student();
                    stu.Id = Convert.ToInt32(dr["id"]);
                    stu.Name = dr["name"].ToString();
                    stu.Percentage = Convert.ToDouble(dr["percentage"]);
                    stu.Course = dr["course"].ToString();
                    list.Add(stu);
                }
            }
            con.Close();
            return list;
        }
        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.Id = Convert.ToInt32(dr["id"]);
                    s.Name = dr["name"].ToString();
                    s.Percentage = Convert.ToDouble(dr["percentage"]);
                    s.Course = dr["course"].ToString();
                }
            }
            con.Close();
            return s;
        }

        public int AddStudent(Student stu)
        {
            stu.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@name,@percentage,@course,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@percentage", stu.Percentage);
            cmd.Parameters.AddWithValue("@course", stu.Course);
            cmd.Parameters.AddWithValue("@isActive", stu.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student stu)
        {
            stu.isActive = 1;
            int result = 0;
            string qry = "update Student set name=@name,percentage=@percentage,course=@course,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@percentage", stu.Percentage);
            cmd.Parameters.AddWithValue("@course", stu.Course);
            cmd.Parameters.AddWithValue("@isActive", stu.isActive);
            cmd.Parameters.AddWithValue("@id", stu.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }     
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update Student set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
