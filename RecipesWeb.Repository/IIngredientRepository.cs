﻿using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Repository
{
    public interface IIngredientRepository
    {
        List<Ingredient> RetrieveAll();
        Ingredient Retrieve(int id);
        Ingredient Create(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
