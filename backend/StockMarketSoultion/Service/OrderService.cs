using Domain_.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Order> GetOrders()
        {
            return _unitOfWork.OrderRepository.GetAllOrders().ToList();
        }

        public void CreateOrder(Order order)
        {
            _unitOfWork.OrderRepository.AddOrder(order);
            _unitOfWork.SaveChanges();
        }
    }

}
