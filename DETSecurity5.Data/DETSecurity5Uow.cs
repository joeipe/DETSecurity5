using DETSecurity5.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DETSecurity5.Data
{
    public class DETSecurity5Uow : IUow
    {
        private readonly DETSecurity5Context _context;

        public DETSecurity5Uow(DETSecurity5Context context)
        {
            _context = context;
        }

        public GenericRepository<Order> OrderRepo { get { return new GenericRepository<Order>(_context); } }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
