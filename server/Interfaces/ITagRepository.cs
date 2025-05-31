using System.Threading.Tasks;
using server.Model;

namespace server.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag?> GetByIdAsync(int id);
    }
}