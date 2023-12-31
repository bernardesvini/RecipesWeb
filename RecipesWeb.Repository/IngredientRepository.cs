﻿using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        public Ingredient Create(Ingredient ingredient)
        {

            string sql = $"INSERT INTO RecipesSystem.dbo.Ingredients (Description) values ('{ingredient.Description}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMaxInt("ID", "Ingredients");
            return Retrieve(maxId);

        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM RecipesSystem.dbo.Ingredients WHERE Id = " + id + ";";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Ingredient Retrieve(int id)
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Ingredients WHERE Id = " + id + ";";

            SqlDataReader dataReader = MSSQL.Execute(sql);

             if (dataReader.Read())
                return Parse(dataReader);

            throw new Exception("Ingredient with id " + id + " not found.");
            //try
            //{
            //    return new Ingredient { Id = Convert.ToInt32(dataReader["ID"]), Description = Convert.ToString(dataReader["Description"]) };
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }

        public List<Ingredient> RetrieveAll()
        {
            string sql = "SELECT * FROM RecipesSystem.dbo.Ingredients;";
            SqlDataReader dataReader = MSSQL.Execute(sql);


            List<Ingredient> ingredients = new List<Ingredient>();
            while (dataReader.Read())
            {
                Ingredient ing = new Ingredient(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["Description"]));
                ingredients.Add(ing);
            }
            return ingredients;

        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = "UPDATE RecipesSystem.dbo.Ingredients SET description = '" + ingredient.Description + "' WHERE Id = " + ingredient.Id + ";";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(ingredient.Id);
        }

        private Ingredient Parse(SqlDataReader reader)
        {
            int ingredientId = Convert.ToInt32(reader["ID"]);
            string ingredientName = Convert.ToString(reader["Description"]);
            Ingredient ingredient = new Ingredient();
            ingredient.Id = ingredientId;
            ingredient.Description = ingredientName;
            return ingredient;
        }

    }
}
