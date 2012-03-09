using MvcNinject.Models;

namespace MvcNinject.Repositories
{
    public interface IBlahRepository
    {
        BlahModel GetBlahTrue();
        BlahModel GetBlahFalse();
        BlahModel[] GetAllBlahs();
    }
}
