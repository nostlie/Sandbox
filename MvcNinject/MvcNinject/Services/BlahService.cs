﻿using MvcNinject.Models;
using MvcNinject.Repositories;

namespace MvcNinject.Services
{
    public class BlahService : IBlahService
    {
        /* This is the service layer. My business logic goes here
         * This layer should pass a valid object to a repository to be persisted (EF, WCF Service, etc.)
         * and pass back a domain model object (BlahModel)
         */

        IBlahRepository _blahRepository;

        public BlahService(IBlahRepository blahRepository)
        {
            _blahRepository = blahRepository;
        }

        public BlahService()
            : this(new BlahRepository())
        {
        }

        public BlahModel GetBlah(bool parameter)
        {
            // Some business logic
            if (parameter)
            {
                return _blahRepository.GetBlahTrue();
            }
            return _blahRepository.GetBlahFalse();
        }

        public BlahModel[] GetAllBlahs()
        {
            return _blahRepository.GetAllBlahs();
        }
    }
}