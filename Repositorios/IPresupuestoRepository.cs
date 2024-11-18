
using tl2_tp6_2024_franleccese11.Models;
namespace tl2_tp6_2024_franleccese11.Repositorios
{
    public interface IPresupuestoRepository
    {
        public void CrearPresupuesto(Presupuesto presupuesto);
        public List<Presupuesto> ListarPresupuestos();
        public List<PresupuestoDetalle> ObtenerDetalle(int id);
        public void EliminarPresupuesto(int id);
    }
}