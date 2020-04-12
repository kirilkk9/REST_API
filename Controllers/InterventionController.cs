using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elevators_API.Contexts;
using Elevators_API.Payloads;

namespace Elevators_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly ApiContext context;

        public InterventionsController(ApiContext context)
        {
            this.context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await this.context.Interventions
                .Where(intervention => intervention.start_intervention == null 
                    && intervention.status == "Pending")
                .ToListAsync();
        }

        // POST: api/Interventions/{id}/status
        [HttpPut("{id}/status")]
        public async Task<ActionResult> UpdateInterventionStatus([FromRoute] long id, [FromBody] UpdateInterventionsPayload payload)
        {
            var myIntervention = await this.context.Interventions.FindAsync(id);

            if (myIntervention == null)
            {
                return NotFound();
            } 
            
            if(payload.status.Equals("InProgress", System.StringComparison.InvariantCultureIgnoreCase))
            {
                myIntervention.start_intervention = System.DateTime.Now;
                myIntervention.status = "InProgress";

            }
            else if(payload.status.Equals("Completed", System.StringComparison.InvariantCultureIgnoreCase))

            {
                myIntervention.end_intervention = System.DateTime.Now;
                myIntervention.status = "Completed";
                
            }
            else
            {
                return BadRequest();
            }

            this.context.Interventions.Update(myIntervention);
            await this.context.SaveChangesAsync();

            return NoContent();
        }
    }
}