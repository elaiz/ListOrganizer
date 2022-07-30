﻿using ListOrganizer.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOrganizer.Repo
{
    public class CategoryRepo : BaseRepo, ICategoryRepo
    {
        public IEnumerable<Category> GetCategories()
        {
            return Db.Categories;
        }

        public Category GetCategory(int id)
        {
            return Db.Categories.Find(id);
        }
    }
}