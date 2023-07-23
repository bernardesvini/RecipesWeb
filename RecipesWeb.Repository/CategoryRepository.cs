using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Create(Category category)
        {
            string sql = $"INSERT INTO RecipesSystem.dbo.Category (Name) values ('{category.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("ID", "Category");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM RecipesSystem.dbo.Category WHERE Id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Category Retrieve(int id)
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Category WHERE Id = " + id + ";";

            SqlDataReader reader = MSSQL.Execute(sql);

                if (reader.Read())
                    return Parse(reader);

            throw new Exception("Category with id " + id + " not found.");


            //try
            //{
            //    if (reader.Read())
            //        return Parse(reader);
            //}
            //catch (Exception ex) 
            //{ 
            //    throw new Exception(ex.Message); 
            //}

            //try
            //{
            //    return new Category { Id = Convert.ToInt32(reader["Id"]), Name = Convert.ToString(reader["Name"]) };
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }

        public List<Category> RetrieveAll()
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Category;";
            SqlDataReader dataReader = MSSQL.Execute(sql);


            List<Category> categories = new List<Category>();
            while (dataReader.Read())
            {
                Category ing = new Category(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["Name"]));
                categories.Add(ing);
            }
            return categories;
        }

        public Category Update(Category category)
        {
            string sql = "UPDATE RecipesSystem.dbo.Category SET name = '" + category.Name + "' WHERE Id = " + category.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(category.Id);
        }

        private Category Parse(SqlDataReader reader)
        {
            int categoryId = Convert.ToInt32(reader["ID"]);
            string categoryName = Convert.ToString(reader["Name"]);
            Category category = new Category();
            category.Id = categoryId;
            category.Name = categoryName;
            return category;
        }
    }
}
