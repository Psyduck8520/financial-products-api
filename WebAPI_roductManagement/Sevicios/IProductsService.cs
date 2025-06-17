using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_roductManagement.Models;

namespace WebAPI_roductManagement.Sevicios
{
    public interface IProductsService
    {
        Task<List<Product>>AllProduct();
        Task<int> AddProduct(Product modelo);
        Task<int> UpdateProduct(Product modelo);
        Task<int> DeleteProduct(string id  );
       
    }
}
