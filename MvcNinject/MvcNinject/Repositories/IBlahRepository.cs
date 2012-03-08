using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
