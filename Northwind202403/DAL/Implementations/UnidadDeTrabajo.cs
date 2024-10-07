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

        private NorthwindContext _northwindContext;

        public UnidadDeTrabajo(NorthwindContext northwindContext, ICategoryDAL categoryDAL)
        {
            this._northwindContext = northwindContext;
            this.CategoryDAL = categoryDAL;
        }
        public bool complete()
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
