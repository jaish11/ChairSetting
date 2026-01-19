using ChairSetting.Data.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChairSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChairController : ControllerBase
    {
        private readonly IChairService _chairService;

        public ChairController(IChairService chairService)
        {
            _chairService = chairService;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_chairService.GetAll());

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(string chairNumber)
            => Ok(_chairService.AddChair(chairNumber));

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, string chairNumber)
            => Ok(_chairService.UpdateChair(id, chairNumber));

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _chairService.DeleteChair(id);
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpPost("occupy/{id}")]
        public IActionResult Occupy(int id)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("UserId").Value);
                _chairService.OccupyChair(id, userId);
                return Ok("Chair occupied successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost("release/{id}")]
        public IActionResult Release(int id)
        {
            var userId = int.Parse(User.FindFirst("UserId").Value);
            _chairService.ReleaseChair(id, userId);
            return Ok("Chair released successfully");
        }

    }
}
