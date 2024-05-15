using Dataedo.Infrastructure.Repositories;
using MediatR;

namespace Dataedo.Application.Commands;

public record DeleteUserCommand(Guid UserId) : IRequest;

public class DeleteUserCommandHandler(IUsersRepository usersRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await usersRepository.DeleteAsync(request.UserId);
    }
}