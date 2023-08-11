using Microsoft.AspNetCore.Mvc;
using Test_C.Dto;
using Test_C.EFCore;
using Test_C.Services;

namespace Test_C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : ControllerBase
    {
        private readonly DrillBlockService _db;
        public DrillBlockController(EF_DataContext eF_DataContext)
        {
            _db = new DrillBlockService(eF_DataContext);
        }
        // GET: 
        [HttpGet]
        [Route("api/GetDrillBlocks")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<DrillBlockDto> data = _db.GetDrillBlocks();

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
        [Route("api/GetDrillBlocksById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                DrillBlockDto data = _db.GetDrillBlocksById(id);

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
        [Route("api/SaveDrillBlocks")]
        public IActionResult Post([FromBody] DrillBlockDto model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.CreateDrillBlocks(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT
        [HttpPut]
        [Route("api/UpdateDrillBlock")]
        public IActionResult Put([FromBody] DrillBlockDto model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateDrillBlocks(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE 
        [HttpDelete]
        [Route("api/DeleteDrillBlock/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteDrillBlock(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
