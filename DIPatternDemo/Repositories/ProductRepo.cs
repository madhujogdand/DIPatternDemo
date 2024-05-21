using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product product)
        {
            product.IsActive = 1;
            int result = 0;
            db.Products.Add(product);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var model = db.Products.Where(product => product.Id == id).FirstOrDefault();
            if (model != null)
            {
                model.IsActive = 0;
                result = db.SaveChanges();
            }
            return result;
        }

        public int EditProduct(Product product)
        {
            int result = 0;
            var model = db.Products.Where(prod => prod.Id == product.Id).FirstOrDefault();
            if (model != null)
            {
                model.Name = product.Name;
                model.Price = product.Price;
                model.IsActive = 1;
                result = db.SaveChanges();
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            return db.Products.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            var model = (from product in db.Products
                         where product.IsActive == 1
                         select product).ToList();
            return model;
        }
    }
}
