using PruebaTecnicaSentry.Models.Db;
using PruebaTecnicaSentry.Repository;
using PruebaTecnicaSentry.Response;

namespace PruebaTecnicaSentry.Data
{
    public class TareaData: IRepository
    {
        public int GuardarTarea(string title, int isComplete)
        {
            try
            {
                using (var db = new Models.Db.PruebaTecnicaSentryContext())
                {
                    TbTask taskExist = db.TbTasks.Where(t => t.Title == title).FirstOrDefault();

                    if (taskExist == null)
                    {
                        var _task = new TbTask();
                        _task.Title = title;
                        _task.Iscompleted = Convert.ToBoolean(isComplete);
                        db.TbTasks.Add(_task);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }

            }catch(Exception ex) 
            {
                return 0;
            }
        }

        public List<ResultTask> ObtenerTareas()
        {
            string _condicion = "";
            List<ResultTask> tasks = new List<ResultTask>();
            using (var db = new Models.Db.PruebaTecnicaSentryContext())
            {

                tasks = (from d in db.TbTasks
                         select new ResultTask
                         {
                             Id = d.Id,
                             Title = d.Title,
                             Estado = (d.Iscompleted ?? false) ? "Completado" : "No completado"
                         }).ToList();
            }
            return tasks;
        }

        public int ActualizarTarea(int id)
        {
            try
            {
                using (var db = new Models.Db.PruebaTecnicaSentryContext())
                {
                    TbTask taskUpdate = db.TbTasks.Where(t => t.Id == id).FirstOrDefault();

                    if (taskUpdate != null)
                    {
                        taskUpdate.Iscompleted = true;
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }

            }catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
