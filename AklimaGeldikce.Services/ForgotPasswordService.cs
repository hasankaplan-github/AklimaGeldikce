using AklimaGeldikce.Entities;
using AklimaGeldikce.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Services
{
    public class ForgotPasswordService : BaseService<ForgotPassword>, IForgotPasswordService
    {
        public ForgotPasswordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
