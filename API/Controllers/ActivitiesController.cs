using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;
using MediatR;
using Application.Activities;
namespace API.Controllers
{
    public class ActivitiesController:BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities(CancellationToken ct){
                    // return await _context.Activities.ToListAsync();
                    return await Mediator.Send(new Application.Activities.List.Query(),ct);
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id){
            
            return await Mediator.Send(new Details.Query{Id=id});
         }

        [HttpPost]
        public async Task<ActionResult<Domain.Activity>> CreateActivity(Domain.Activity activity){
             await Mediator.Send(new Create.Command{Activity=activity});
             return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Domain.Activity>> EditActivity(Guid id, Domain.Activity activity){
            activity.Id = id;
            await Mediator.Send(new Edit.Command{Activity=activity});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Activity>> DeleteActivity(Guid id){
            await Mediator.Send(new Delete.Command{Id=id});
            return Ok();
        }
    }
}