using SharedKernel;
using System;

namespace DETSecurity5.Domain
{
    public class Order : Entity
    {
        public string OrderNumber { get; set; }
        public StoreUser User { get; set; }
    }
}
