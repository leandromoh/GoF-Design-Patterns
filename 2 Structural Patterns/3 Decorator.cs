Decorator: Attach additional responsibilities to an object dynamically. 
Decorators provide a flexible alternative to subclassing for extending functionality.

    class UserRepositoryLogTimeDecorator : IUserRepository
    {
        private readonly IUserRepository _repository;

        public UserRepositoryLogTimeDecorator(IUserRepository repository) => _repository = repository;
        
        public User GetById(int id)
        {
            logger.Write($"IUserRepository.GetById was called for id {id}, starting at {DateTime.Now}");
            var user = _repository.GetById(id);
            logger.Write($"IUserRepository.GetById was called for id {id}, ending at {DateTime.Now}");
            return user;
        }
    }

	void Main()
	{
		IUserRepository repository = new UserRepository();
		IUserRepository repositoryLogTime = new UserRepositoryLogTimeDecorator(repository);
		IUserRepository repositoryLogTimeAndError = new UserRepositoryLogErrorDecorator(repositoryLogTime);
	}