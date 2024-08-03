using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using PruebaTecnicaSentry.Models.Db;
using PruebaTecnicaSentry.Models.EntitiesEntry;
using PruebaTecnicaSentry.Repository;
using PruebaTecnicaSentry.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {

        private readonly IRepository _IRepository;

        public TareasController(IRepository repository)
        {
            _IRepository = repository;
        }

        // GET api/<TareasController>/5
        [HttpGet("[action]")]
        public IActionResult ObtenerTareas()
        {
            try
            {
                List<ResultTask> tasks = new List<ResultTask>();
                tasks = _IRepository.ObtenerTareas();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace + ex.InnerException);
            }
        }

        // POST api/<TareasController>
        [HttpPost("[action]")]
        public IActionResult GuardarTarea([FromBody] Tarea ts)
        {
            try
            {
                List<ResultResponse> lsResult = new List<ResultResponse>();
                string _result = "";
                int isSaveTask = 0;


                if (ts.title != "")
                {
                    isSaveTask = _IRepository.GuardarTarea(ts.title, ts.isCompete);
                    if (isSaveTask == 1)
                    {
                        _result = "Tarea registrada con exito";
                        lsResult.Add(new ResultResponse(_result) { });
                        return Ok(lsResult);
                    }
                    else if(isSaveTask == 2)
                    {
                        _result = "La tarea que desea registrar ya existe";
                        lsResult.Add(new ResultResponse(_result) { });
                        return BadRequest(lsResult);
                    }
                    else
                    {
                        _result = "Tarea no creada con exito";
                        lsResult.Add(new ResultResponse(_result) { });
                        return BadRequest(lsResult);
                    }
                }
                else
                {
                    _result = "El campo titulo no puede ir vacio";
                    lsResult.Add(new ResultResponse(_result) { });
                    return BadRequest(lsResult);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }
        }

        // PUT api/<TareasController>/5
        [HttpPut("[action]")]
        public IActionResult ActualizarTarea(int id)
        {
            try
            {
                List<ResultResponse> lsResult = new List<ResultResponse>();
                string _result = "";

                int updateTask = 0;
                updateTask = _IRepository.ActualizarTarea(id);

                if (updateTask == 1)
                {
                    _result = "Tarea actualizada con exito";
                    lsResult.Add(new ResultResponse(_result) { });
                    return Ok(lsResult);
                }
                else
                {
                    _result = "La tarea que desea actualizar no existe";
                    lsResult.Add(new ResultResponse(_result) { });
                    return BadRequest(lsResult);

                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.Source + ex.StackTrace);
            }

        }
    }
}
