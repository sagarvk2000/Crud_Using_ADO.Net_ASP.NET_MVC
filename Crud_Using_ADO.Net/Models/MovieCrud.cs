using System.Data.SqlClient;

namespace Crud_Using_ADO.Net.Models
{
    public class MovieCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public MovieCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Movies> GetAllMovies()
        {
            List<Movies> list = new List<Movies>();
            string qry = "select * from Movie where isActive=1";
            con.Open();
            cmd = new SqlCommand(qry, con);
       
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Movies m = new Movies();
                    m.Mid = Convert.ToInt32(dr["Id"]);
                    m.Mname = dr["Mname"].ToString();
                    m.Rdate = Convert.ToDateTime(dr["ReleaseDate"]);
                    m.Genre = dr["Genre"].ToString();
                    m.Sname = dr["StarsName"].ToString();
                    list.Add(m);
                }
            }
            con.Close();
            return list;
        }
        public Movies GetMovieById(int id)
        {
            Movies m = new Movies();
            string qry = "select * from Movie where id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    m.Mid = Convert.ToInt32(dr["Id"]);
                    m.Mname = dr["Mname"].ToString();
                    m.Rdate = Convert.ToDateTime(dr["ReleaseDate"]);
                    m.Genre = dr["Genre"].ToString();
                    m.Sname = dr["StarsName"].ToString();
                }
            }
            con.Close();
            return m;
        }
        public int AddMovie(Movies movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "insert into Movie values(@Mname,@ReleaseDate,@Genre,@StarsName,@isActive)";
            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.Rdate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarsName", movie.Sname);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
           
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateMovie(Movies movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "update Movie set Mname=@Mname,ReleaseDate=@ReleaseDate,Genre=@Genre,StarsName=@StarsName,isActive=@isActive where id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.Rdate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarsName", movie.Sname);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            cmd.Parameters.AddWithValue("@Id", movie.Mid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteMovie(int id)
        {
            int result = 0;
            string qry = "update Movie set isActive=0 where id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
