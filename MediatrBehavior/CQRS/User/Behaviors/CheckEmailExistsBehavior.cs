using MediatR;
using MediatrBehavior.CQRS.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MediatrBehavior.CQRS.User.Behaviors
{
	public class CheckEmailExistsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly DbContext _dbContext;

		public CheckEmailExistsBehavior(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var t = typeof(TResponse);
			if (request is AddUserCommand addUserCommand)
			{
				var list = await _dbContext.GetUsersAsync();
				bool exist = list.Any(x => x.Email == addUserCommand.Mail);
				if (exist)
				{
					throw new Exception("E posta kayıtlı");
				}
			}

			return await next();
		}
	}
}