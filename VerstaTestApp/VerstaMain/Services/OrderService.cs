using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VerstaMain.Data;
using VerstaMain.Data.Models;
using VerstaMain.Models;

namespace VerstaMain.Services
{
    public class OrderService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public OrderService(DataContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Guid> AddOrder(AddOrderModel model)
        {
            var newOrder = mapper.Map<Order>(model);
            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();
            return newOrder.Id;
        }

        internal async Task<GetOrderModel> GetOrderByID(Guid id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if(order is null)
            {
                throw new Exception("Заказ с таким id не найден");
            }
            var model = mapper.Map<GetOrderModel>(order);
            return model;
        }

        internal async Task<int> GetOrderCount()
        {
            var orderCount = await context.Orders.CountAsync();
            return orderCount;
        }

        internal async Task<IEnumerable<GetOrderModel>> GetOrders()
        {
            var orders = await context.Orders.Select(o => mapper.Map<GetOrderModel>(o)).ToListAsync();
            return orders;
        }
    }
}
