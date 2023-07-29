using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public class DifficultRepository : IDifficultRepository
    {
        public Difficult Create(Difficult difficult)
        {
            string sql = $"INSERT INTO RecipesSystem.dbo.Difficult (difficult_name) values ('{difficult.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("ID", "Difficult");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM RecipesSystem.dbo.Difficult WHERE Id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Difficult Retrieve(int id)
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Difficult WHERE Id = " + id + ";";

            SqlDataReader reader = MSSQL.Execute(sql);

            if (reader.Read())
                return Parse(reader);

            throw new Exception("Category with id " + id + " not found.");
         
        }

        public List<Difficult> RetrieveAll()
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Difficult;";
            SqlDataReader dataReader = MSSQL.Execute(sql);


            List<Difficult> difficults = new List<Difficult>();
            while (dataReader.Read())
            {
                Difficult diff = new Difficult(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["difficult_name"]));
                difficults.Add(diff);
            }
            return difficults;
        }

        public Difficult Update(Difficult difficult)
        {
            string sql = "UPDATE RecipesSystem.dbo.Difficult SET difficult_name = '" + difficult.Name + "' WHERE Id = " + difficult.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(difficult.Id);
        }

        private Difficult Parse(SqlDataReader reader)
        {
            int difficultId = Convert.ToInt32(reader["ID"]);
            string difficultName = Convert.ToString(reader["difficult_name"]);
            Difficult difficult = new Difficult();
            difficult.Id = difficultId;
            difficult.Name = difficultName;
            return difficult;
        }
    }
}
