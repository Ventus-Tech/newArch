using System.Threading.Tasks;

namespace t.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
