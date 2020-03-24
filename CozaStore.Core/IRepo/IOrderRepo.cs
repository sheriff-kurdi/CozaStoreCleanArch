using CozaStore.Core.Entities;
using CozaStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozaStore.Core.IRepo
{
    public interface IOrderRepo
    {
        Order RequestOrder(RequestOrderVM order);
        Order GetOrdertByID(int id);
        IEnumerable<Order> GetAllOrders();
        void Delete(Order pro);
        void Update(Order proToUpdate);
    }
}
