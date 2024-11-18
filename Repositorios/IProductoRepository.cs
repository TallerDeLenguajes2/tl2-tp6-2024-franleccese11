using tl2_tp6_2024_franleccese11.Models;
namespace tl2_tp6_2024_franleccese11.Repositorios
{
    public interface IProductoRepository
    {
        public bool ValidarID(int id);
        public List <Producto> ListarProductos();
        public void InsertProducto(Producto producto);
        public Producto ObtenerProducto(int id);
        public void DeleteProducto(int id);
        
    }
}