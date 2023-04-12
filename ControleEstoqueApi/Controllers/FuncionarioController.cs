using ControleEstoqueApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace ControleEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<FuncionarioModel>> BuscarTodosUsuarios()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public FuncionarioModel Get(int id)
        {

            return new FuncionarioModel();
        }

        [HttpPost]
        public void Post([FromBody] FuncionarioModel usuario)
        {


        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FuncionarioModel usuario)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
