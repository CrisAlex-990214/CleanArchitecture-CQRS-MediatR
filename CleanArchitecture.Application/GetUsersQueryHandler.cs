using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application
{
    public class GetUsersRequest : IRequest<List<GetUserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersRequest, List<GetUserDto>>
    {
        private readonly IDatabaseService databaseService;

        public GetUsersQueryHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public Task<List<GetUserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = databaseService.GetUsers();

            return Task.FromResult(users.Select(x => new GetUserDto() { Id = x.Id, Name = x.Name }).ToList());
        }
    }
}
