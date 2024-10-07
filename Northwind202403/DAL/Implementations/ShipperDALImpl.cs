using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : DALGenericoImpl<Shipper>, IShipperDAL
    {
        private NorthwindContext context;

        public ShipperDALImpl(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
    }
}
