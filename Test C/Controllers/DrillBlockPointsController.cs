using Microsoft.AspNetCore.Mvc;
using Test_C.Dto;
using Test_C.EFCore;
using Test_C.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointsController : ControllerBase
    {
        private readonly DrillBlockPointsService _db;
        public DrillBlockPointsController(EF_DataContext eF_DataContext)
        {
            _db = new DrillBlockPointsService(eF_DataContext);
        }
        // GET: 
        [HttpGet]
        [Route("api/GetDrillBlockPoints")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<DrillBlockPointsDto> data = _db.GetDrillBlockPoints();

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

        // GET
        [HttpGet]
        [Route("api/GetDrillBlockPointsById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                DrillBlockPointsDto data = _db.GetDrillBlockPointsById(id);

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

        // POST
        [HttpPost]
        [Route("api/SaveDrillBlockPoint")]
        public IActionResult Post([FromBody] DrillBlockPointsDto model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateDrillBlockPoint(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT
        [HttpPut]
        [Route("api/UpdateDrillBlockPoint")]
        public IActionResult Put([FromBody] DrillBlockPointsDto model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateDrillBlockPoints(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE 
        [HttpDelete]
        [Route("api/DeleteDrillBlockPoint/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteDrillBlockPoint(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
