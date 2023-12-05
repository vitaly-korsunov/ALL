using DAL.Repository.IRepository;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            // _db.Products.Update(obj);
            var objFromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.Active = obj.Active;
                objFromDb.CreatedDate = obj.CreatedDate;
                objFromDb.Addings = obj.Addings;
                //objFromDb.CategoryId = obj.CategoryId;
                //objFromDb.CoverTypeId = obj.CoverTypeId;

            }
        }
    }
}
