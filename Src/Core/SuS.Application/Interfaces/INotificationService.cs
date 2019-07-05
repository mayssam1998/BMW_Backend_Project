using System.Threading.Tasks;
using SuS.Common.Models;

namespace SuS.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
