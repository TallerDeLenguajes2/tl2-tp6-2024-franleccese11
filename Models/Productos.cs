namespace tl2_tp6_2024_franleccese11.Models;

public class Producto
{
    private int idProducto;
    private string descripcion;
    private int precio;

    public int Precio { get => precio; set => precio = value; }
    public int IdProducto { get => idProducto; set=> idProducto=value;}
    public string Descripcion { get => descripcion; set => descripcion = value; }

    public void SetID(int id)
    {
        idProducto = id;
    }
}