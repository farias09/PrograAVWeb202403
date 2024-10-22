﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : DALGenericoImpl<Category>, ICategoryDAL
    {

        private NorthwindContext context;

        public CategoryDALImpl(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        
    }
}
