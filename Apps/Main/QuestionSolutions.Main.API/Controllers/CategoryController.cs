using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Web.Http;

namespace QuestionSolutions.Main.API.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Application.Queries.Category.GetById.Query query)
            => Ok(await _mediator.Send(query));
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] Application.Queries.Category.GetAll.Query query)
            => Ok(await _mediator.Send(query));

        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync([FromBody] Application.Commands.Category.Insert.Command command)
            => Ok(await _mediator.Send(command));
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Application.Commands.Category.Update.Command command)
            => Ok(await _mediator.Send(command));
    }
}