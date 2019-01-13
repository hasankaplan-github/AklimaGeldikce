using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class RequestService : BaseService<Request>, IRequestService
    {
        public RequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
