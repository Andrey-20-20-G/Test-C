using Microsoft.AspNetCore.Mvc;
using Test_C.Dto;
using Test_C.EFCore;
using Test_C.Services;

namespace Test_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleController : ControllerBase
    {
        private readonly HoleService _db;
        public HoleController(EF_DataContext eF_DataContext)
        {
            _db = new HoleService(eF_DataContext);
        }
        // GET: api/<HoleController>
        [HttpGet]
        [Route("api/GetHoles")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<HoleDto> data = _db.GetHoles();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<HoleController>/5
        [HttpGet]
        [Route("api/GetHolesById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                HoleDto data = _db.GetHoleById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<HoleController>
        [HttpPost]
        [Route("api/CreateHole")]
        public IActionResult Post([FromBody] HoleDto model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateHole(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<HoleController>/5
        [HttpPut]
        [Route("api/UpdateHole")]
        public IActionResult Put([FromBody] HoleDto model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateHole(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<HoleController>/5
        [HttpDelete]
        [Route("api/DeleteHole/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteHole(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
