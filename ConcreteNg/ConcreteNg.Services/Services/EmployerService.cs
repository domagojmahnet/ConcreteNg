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

        public int CreateOrUpdatePricingListItem(PricingListItem item)
        {
            if (item.PricingListItemId == -1)
            {
                Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                unitOfWork.pricingListRepository.Create(new PricingListItem(item.PricingListItemName, item.UnitOfMeasurement, item.Price, employer));
            }
            else
            {
                var pricingListItem = unitOfWork.pricingListRepository.Read(item.PricingListItemId);
                pricingListItem.Price = item.Price;
                pricingListItem.UnitOfMeasurement = item.UnitOfMeasurement;
                pricingListItem.PricingListItemName = item.PricingListItemName;
                unitOfWork.pricingListRepository.Update(pricingListItem);
            }
            return unitOfWork.Complete();
        }

        public int DeletePricingListItem(int id)
        {
            var itemToDelete = unitOfWork.pricingListRepository.Read(id);
            unitOfWork.pricingListRepository.Delete(itemToDelete);
            return unitOfWork.Complete();
        }

        public IEnumerable<PricingListItem> GetEmployersPricingListItems()
        {
            return unitOfWork.pricingListRepository.GetEmployersPricingListItems(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public TableResponse GetEmployersPricingListItemsTable(TableRequest tableRequest)
        {
            return unitOfWork.pricingListRepository.GetEmployersPricingListItemsTable(tableRequest ,int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }
    }
}
