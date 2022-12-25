using MediatR;
using MediatrBehavior.CQRS.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MediatrBehavior.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ValuesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> AddUser(AddUserCommand user)
		{
			var result = _mediator.Send(user);
			return Ok(result);
		}
	}
}