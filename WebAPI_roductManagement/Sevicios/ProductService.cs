using Microsoft.EntityFrameworkCore;
using WebAPI_roductManagement.Models;

namespace WebAPI_roductManagement.Sevicios
{
    public class ProductService : IProductsService
    {
        private readonly ProductFlowDbContext _context;
        private readonly DbSet<Product> _dbset; // definiendo   con que modelo vamos  a trabajar

        public ProductService(ProductFlowDbContext context) // Inyección de dependencias
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbset = _context.Set<Product>();

        }
        public async Task<int> AddProduct(Product modelo)
        {
          //Agrega la entidad  al changeTracer 
           await _context.Products.AddAsync(modelo); //Estamos  trabajando con funciones asincronas
          //Captura cuantas filas fueron afectadas
          int filasAfectadas = await _context.SaveChangesAsync();
           return filasAfectadas;
        }
        public async Task<List<Product>> AllProduct()
        {
            return await _dbset.ToListAsync(); // Trae todos los productos de la base de datos
        }

        public async Task<int> DeleteProduct(string id )
        {
            var producto = await _context.Products.FindAsync(id);   
            if(producto == null)
            {
                return 0; // Producto no encontrado
            }
            _context.Products.Remove(producto); // Elimina el producto de la base de datos
            return await _context.SaveChangesAsync(); // Guarda los cambios y devuelve el número de filas afectadas

        }

        public async Task<int> UpdateProduct(Product modelo)
        {
            _context.Products.Update(modelo); // Actualiza el producto en la base de datos
            return  await _context.SaveChangesAsync(); // Guarda los cambios y devuelve el número de filas afectadas
        }
         
    }
}
