﻿using RecipesWeb.Model;
using System;
using System.Collections.Generic;
using RecipesWeb.Repository;

namespace RecipesWeb.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository = new IngredientRepository();
        public void Create(Ingredient ingredient)
        {
            _ingredientRepository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
            return _ingredientRepository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _ingredientRepository.RetrieveAll();
        }

        public void Update(Ingredient ingredient)
        {
            _ingredientRepository.Update(ingredient);
        }
    }
}
