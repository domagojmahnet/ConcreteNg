using ConcreteNg.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EmployerService(IHttpContextAccessor _httpContextAccessor, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            httpContextAccessor = _httpContextAccessor;
        }

        public PricingListItem AddPricingListItem(PricingListItem item)
        {
            throw new NotImplementedException();
        }

        public TableResponse GetEmployersPricingListItemsTable(TableRequest tableRequest)
        {
            return unitOfWork.pricingListRepository.GetEmployersPricingListItemsTable(tableRequest ,int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            return null;
        }
    }
}
