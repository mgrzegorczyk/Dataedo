using Dataedo.Application.Dtos;
using Dataedo.Infrastructure.Repositories;
using MediatR;

namespace Dataedo.Application.Queries
{
    public record GetUsersQuery : IRequest<IEnumerable<UserDto>>;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetAll();

            return users.Select(user => new UserDto(
                user.Id,
                user.IsActive,
                user.Name
            ));
        }
    }
}