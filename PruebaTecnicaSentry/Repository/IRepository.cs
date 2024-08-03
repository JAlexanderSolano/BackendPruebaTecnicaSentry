using PruebaTecnicaSentry.Models.Db;
using PruebaTecnicaSentry.Response;

namespace PruebaTecnicaSentry.Repository
{
    public interface IRepository
    {
        // metodos para consumir cada peticion
        int GuardarTarea(string title, int isComplete);

        List<ResultTask> ObtenerTareas();

        int ActualizarTarea(int id);
    }
}
