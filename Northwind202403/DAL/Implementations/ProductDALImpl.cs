using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;


namespace DAL.Implementations
{
    public class ProductDALImpl : DALGenericoImpl<Product>, IProductDAL
    {
        NorthwindContext NorthwindContext;

        public ProductDALImpl(NorthwindContext northwindContext): base(northwindContext)
        {
            this.NorthwindContext = northwindContext;
        }
    }
}
