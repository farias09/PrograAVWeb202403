using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public ICategoryDAL CategoryDAL { get; set; }

        public IShipperDAL ShipperDAL { get; set; }

        public ISupplierDAL SupplierDAL { get; set; }

        public IProductDAL ProductDAL { get; set; }

        private NorthwindContext _northwindContext;

        public UnidadDeTrabajo(NorthwindContext northwindContext, ICategoryDAL categoryDAL, IShipperDAL shipperDAL, ISupplierDAL supplierDAL, IProductDAL productDAL)
        {
            this._northwindContext = northwindContext;
            this.CategoryDAL = categoryDAL;
            this.ShipperDAL = shipperDAL;
            this.SupplierDAL = supplierDAL;
            this.ProductDAL = productDAL;
        }
        public bool Complete()
        {
            try
            {
                _northwindContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._northwindContext.Dispose();
        }
    }
}
