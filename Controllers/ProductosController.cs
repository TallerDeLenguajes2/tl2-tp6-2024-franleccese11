namespace tl2_tp6_2024_franleccese11.Controllers;

using Microsoft.AspNetCore.Mvc;
using tl2_tp6_2024_franleccese11.Repositorios;
using tl2_tp6_2024_franleccese11.Models;
using System.Diagnostics;


using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

public class ProductosController : Controller
{
    private readonly ProductoRepository repoProducto;

    public ProductosController()
    {
        repoProducto = new();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(repoProducto.ListarProductos());
    }


    [HttpGet]
    public IActionResult CrearProducto()
    {
        return View();
    }


    [HttpPost]
    public IActionResult CrearProducto(Producto producto)
    {
        if (ModelState.IsValid)
        {
            repoProducto.InsertProducto(producto);
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }


    [HttpGet]
    public IActionResult ModificarProducto(int id)
    {
        var producto = repoProducto.ObtenerProducto(id);
        if (producto is null)
        {
            return NotFound();
        }
        return View(producto);
    }


    [HttpPost]
    public IActionResult ModificarProduct(Producto producto)
    {
       
        repoProducto.UpdateProducto(producto);
        return RedirectToAction("Index");
    }

   
    [HttpGet]
    public IActionResult EliminarProducto(int id)
    {
        var producto = repoProducto.ObtenerProducto(id);
        if (producto is null)
        {
            return NotFound();
        }
        return View(producto);
    }

    [HttpPost]
    public IActionResult EliminacionConfirmadaProducto(int id)
    {
        
        repoProducto.DeleteProducto(id);
        return RedirectToAction("Index");
    }

}