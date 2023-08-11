using Microsoft.AspNetCore.Mvc;
using Test_C.Dto;
using Test_C.EFCore;
using Test_C.Services;

namespace Test_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointsController : ControllerBase
    {
        private readonly HolePointsService _db;
        public HolePointsController(EF_DataContext eF_DataContext)
        {
            _db = new HolePointsService(eF_DataContext);
        }
        // GET: api/<HolePointsController>
        [HttpGet]
        [Route("api/GetHolePoints")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<HolePointsDto> data = _db.GetHolePoints();

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
        [Route("api/GetHolePointsById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                HolePointsDto data = _db.GetHolePointsById(id);

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
        [Route("api/CreateHolePoint")]
        public IActionResult Post([FromBody] HolePointsDto model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateHolePoints(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<HoleController>/5
        [HttpPut]
        [Route("api/UpdateHolePoint")]
        public IActionResult Put([FromBody] HolePointsDto model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateHolePoints(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<HoleController>/5
        [HttpDelete]
        [Route("api/DeleteHolePoint/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteHolePoints(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
