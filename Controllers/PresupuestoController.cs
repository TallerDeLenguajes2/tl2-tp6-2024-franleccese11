namespace tl2_tp6_2024_franleccese11.Controllers;

using Microsoft.AspNetCore.Mvc;
using tl2_tp6_2024_franleccese11.Repositorios;
using  tl2_tp6_2024_franleccese11.Models;
using System.Diagnostics;


using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

public class PresupuestoController: Controller
{
    private readonly PresupuestoRepository repoPresupuesto;
    private readonly ProductoRepository repoProducto;

    public PresupuestoController()
    {
        repoPresupuesto = new();
        repoProducto = new();
    }

    public IActionResult Index()
    {
        return View(repoPresupuesto.ListarPresupuestos());
    }

    [HttpGet]
    public IActionResult CrearPresupuesto()
    {
        return View();
    }

    
    [HttpPost]
    public IActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        if (ModelState.IsValid)
        {
            presupuesto.Fecha = DateTime.Now;
            // Crear presupuesto y obtener el ID generado
            repoPresupuesto.CrearPresupuesto(presupuesto);

            // Redirigir a la acción AgregarDetalle pasando el ID del presupuesto
            return RedirectToAction("Index");
        }
        return View(presupuesto);
    }

    [HttpGet]
    public IActionResult AsignarProducto(int id)
    {
        var presupuesto = repoPresupuesto.ObtenerPresupuesto(id);
        return View(presupuesto);
    }

    [HttpPost]
    public IActionResult AsignarProducto(int id, int idProducto, int cantidad)
    {   
        repoPresupuesto.AgregarDetalle(id, idProducto, cantidad);
        return RedirectToAction("Index");
    }

   





}

