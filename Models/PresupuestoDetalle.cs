namespace tl2_tp6_2024_franleccese11.Models;
using tl2_tp6_2024_franleccese11.Repositorios;


public class PresupuestoDetalle
{
    private Producto producto;
    private int cantidad;

    
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public Producto Producto { get => producto; set => producto = value; }

    public void AsignarProducto(int id)
    {
        var repositorioProductos = new ProductoRepository();
        Producto = repositorioProductos.ObtenerProducto(id);
        
    }

    public Producto ObtenerProducto()
    {
        return Producto;
    }
    
    public int ObtenerIdProducto()
    {
        return Producto.IdProducto;
    }
}   