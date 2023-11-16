using CleanArchitecture.Application.Events;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application
{
    public class CreateUserEventHandler : INotificationHandler<CreateUserEvent>
    {
        private readonly IDatabaseService databaseService;

        public CreateUserEventHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public async Task Handle(CreateUserEvent notification, CancellationToken cancellationToken)
        {
            //Sync
            await Task.Delay(5000);
            databaseService.AddUser(notification.Name);
        }
    }
}
