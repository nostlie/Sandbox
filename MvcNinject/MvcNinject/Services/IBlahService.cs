using MvcNinject.Models;

namespace MvcNinject.Services
{
    public interface IBlahService
    {
        BlahModel GetBlah(bool parameter);
        BlahModel[] GetAllBlahs();
    }
}
