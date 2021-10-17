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
        public async Task<IActionResult> GetForEmployeeDocumentAsync([FromQuery] Application.Queries.Category.GetById.Query query)
            => Ok(await _mediator.Send(query));
    }
}