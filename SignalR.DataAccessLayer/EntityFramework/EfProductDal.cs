using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRDbContext _context;

        public EfProductDal(SignalRDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductsWithCategories()
        {
           var values = _context.Products.Include(x=>x.Category).ToList();

            return values;
        }
    }
}
