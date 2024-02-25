namespace MediatrBehavior
{
	public class DbContext
	{
		private readonly List<UserEntity> _users = new()
		{
			new () { Id = Guid.NewGuid(), Name ="user1", Email="user1@mail.com"},
			new () { Id = Guid.NewGuid(), Name ="user2", Email="user2@mail.com"},
			new () { Id = Guid.NewGuid(), Name ="user3", Email="user3@mail.com"},
			new () { Id = Guid.NewGuid(), Name ="user4", Email="user4@mail.com"},
			new () { Id = Guid.NewGuid(), Name ="user5", Email="user5@mail.com"},
		};

		public UserEntity AddUser(UserEntity user)
		{
			_users.Add(user);
			return user;
		}

		public async Task<IEnumerable<UserEntity>> GetUsersAsync()
		{
			return await Task.FromResult(_users);
		}
	}
}