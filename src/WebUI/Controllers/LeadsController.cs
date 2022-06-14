using fw.Application.Leads.Commands.Accept;
using fw.Application.Leads.Commands.Decline;
using fw.Application.Leads.Queries; 
using fw.Application.Leads.Queries.GetLeads.GetAcceptedLeads;
using fw.Application.Leads.Queries.GetLeads.GetInvitedLeads;
using fw.Application.Leads.Queries.GetOptions;
using Microsoft.AspNetCore.Mvc;

namespace fw.WebUI.Controllers;

public class LeadsController : ApiControllerBase
{
    [HttpGet("GetOptions")]
    public async Task<IEnumerable<LeadStatusDto>> GetOptions()
    {
        return await Mediator.Send(new GetOptionsLeadQuery());
    }

    [HttpGet("GetInvited")]
    public async Task<IEnumerable<LeadDto>> GetInvited()
    {
        return await Mediator.Send(new GetInvitedLeadsQuery());
    }

    [HttpGet("GetAccepted")]
    public async Task<IEnumerable<LeadDto>> GetAccepted()
    {
        return await Mediator.Send(new GetAcceptedLeadsQuery());
    }
     
    [HttpPut("Accept/{id}")]
    public async Task<ActionResult> Accept(int id, AcceptCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
      
    [HttpPut("Decline/{id}")]
    public async Task<ActionResult> Decline(int id, DeclineCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}