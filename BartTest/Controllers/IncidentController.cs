using BartTest.Dto;
using BartTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BartTest.Controllers
{
    [ApiController]
    [Route("Incident")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewIncident([FromBody] AddNewIncidentDto addNewIncidentDto)
        {
            var addedIncident = await incidentService.AddNewIncidentAsync(addNewIncidentDto);

            return addedIncident == null ? NotFound() : Ok(addedIncident);
        }
    }
}
