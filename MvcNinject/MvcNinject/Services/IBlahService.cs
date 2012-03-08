using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcNinject.Models;

namespace MvcNinject.Services
{
    public interface IBlahService
    {
        BlahModel GetBlah(bool parameter);
        BlahModel[] GetAllBlahs();
    }
}
