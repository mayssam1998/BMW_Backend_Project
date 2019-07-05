using System.Threading.Tasks;
using SuS.Application.Interfaces;
using SuS.Common.Models;

namespace SuS.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
