using MediatR;

namespace MediatrBehavior.CQRS.User.Commands
{
	public sealed record AddUserCommand(string Name, string Mail) : IRequest<IEnumerable<UserEntity>>
	{
	}

	public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, IEnumerable<UserEntity>>
	{
		private readonly DbContext _dbContext;

		public AddUserCommandHandler(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<UserEntity>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			UserEntity user = new() { Name = request.Name, Email = request.Mail };

			_dbContext.AddUser(user);

			return await _dbContext.GetUsersAsync();
		}
	}
}