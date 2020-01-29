using AutoMapper;
using DETSecurity5.Api.ViewModels;
using DETSecurity5.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DETSecurity5.Data.Services
{
    public class DETSecurity5DataService
    {
        private readonly IMapper _mapper;
        private readonly DETSecurity5Uow _uow;

        public DETSecurity5DataService(IMapper mapper, DETSecurity5Uow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        #region Order
        public IList<OrderVM> GetOrders()
        {
            var data = _uow.OrderRepo.GetAll();
            var vm = _mapper.Map<IList<OrderVM>>(data);
            return vm;
        }

        public OrderVM GetOrderById(int id)
        {
            var data = _uow.OrderRepo.GetById(id);
            var vm = _mapper.Map<OrderVM>(data);
            return vm;
        }

        public IList<OrderVM> GetOrdersByUserId(string userId)
        {
            var data = _uow.OrderRepo.SearchFor
                (
                    o => o.User.Id == userId
                );
            var vm = _mapper.Map<IList<OrderVM>>(data);
            return vm;
        }

        public void AddOrder(OrderVM value)
        {
            var data = _mapper.Map<Order>(value);
            _uow.OrderRepo.Add<Order>(data);
            _uow.Save();
        }

        public void UpdateOrder(OrderVM value)
        {
            var data = _mapper.Map<Order>(value);
            _uow.OrderRepo.Edit<Order>(data);
            _uow.Save();
        }

        public void DeleteOrder(OrderVM value)
        {
            var data = _mapper.Map<Order>(value);
            _uow.OrderRepo.Delete(data);
            _uow.Save();
        }
        #endregion Order
    }
}
