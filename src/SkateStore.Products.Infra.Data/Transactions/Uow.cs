using SkateStore.Products.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkateStore.Products.Infra.Data.Transactions
{
    public class Uow : IUow
    {
        private readonly ProductDbContext _context;

        public Uow(ProductDbContext context)
        {
            _context = context;
        }
        public int Commit()
        {

            try
            {
                return _context.SaveChanges();
            }
            catch (System.Exception e)
            {                
                throw;
            }

        }

    }
}
