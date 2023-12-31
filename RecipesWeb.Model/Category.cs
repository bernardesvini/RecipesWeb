﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category()
        {
        }
        public override string ToString()
        {
            return "ID: " + Id + "\nName: " + Name;
        }
    }
}
