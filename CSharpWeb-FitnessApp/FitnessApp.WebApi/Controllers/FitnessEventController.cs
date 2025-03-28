using System.Security.Claims;
using FitnessApp.Services.Data.Contracts;
using FitnessApp.Web.ViewModels.FitnessEventViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessEventController : ControllerBase
    {
        private readonly IFitnessEventService _fitnessEventService;

        public FitnessEventController(IFitnessEventService fitnessEventService)
        {
            _fitnessEventService = fitnessEventService;
        }

        protected string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AllFitnessEventsViewModel>>> GetAll()
        {
            var events = await _fitnessEventService.GetAllFitnessEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FitnessEventDetailsViewModel>> GetById(int id)
        {
            var fitnessEvent = await _fitnessEventService.GetFitnessEventDetailsAsync(id);
            if (fitnessEvent == null)
            {
                return NotFound("Fitness event not found");
            }
            return Ok(fitnessEvent);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddFitnessEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();

            if (userId != null)
            {
                return BadRequest("User ID is required.");
            }

            if (userId != null) await _fitnessEventService.AddFitnessEventAsync(model, userId);

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update( [FromBody] FitnessEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fitnessEvent = await _fitnessEventService.GetFitnessEventDetailsAsync(model.Id);
            if (fitnessEvent == null)
            {
                return NotFound("Fitness event doesn't exist");
            }

            var userId = GetUserId();

            if (userId != null) await _fitnessEventService.EditFitnessEventAsync(model, userId);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var fitnessEvent = await _fitnessEventService.GetFitnessEventDetailsAsync(id);
            if (fitnessEvent == null)
            {
                return NotFound("Fitness event not found");
            }

            var userId = GetUserId();

            if (userId != null) await _fitnessEventService.DeleteFitnessEventAsync(id, userId);
            return Ok("Fitness event deleted successfully");
        }
    }
}