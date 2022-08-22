using Code.Handlers.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringPatternController : Controller
    {
        private readonly IMediator _mediator;

        public StringPatternController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "Find")]
        public async Task<string> Find(string input, string user)
        {
            var requestCommand = new InfoRequest() 
            {   
                Input = input, 
                User = user, 
                RequestDate = DateTime.UtcNow 
            };
            
            // Here we are appliying Mediator Pattern
            // Mediator will connect the info request to its handler 
            var result = await _mediator.Send(requestCommand);
            return result;
        }
    }
}
