using ConcreteNg.Repositories;
using ConcreteNg.Repositories.TableRequestHelpers;
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

        public int AddEditPartner(Partner partner)
        {
            if (partner.PartnerId == -1)
            {
                Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                unitOfWork.partnerRepository.Create(new Partner(partner.Name, partner.Address, partner.ContactPerson, partner.ContactNumber, employer));
            }
            else
            {
                var partnerToUpdate = unitOfWork.partnerRepository.Read(partner.PartnerId);
                partnerToUpdate.Name = partner.Name;
                partnerToUpdate.Address = partner.Address;
                partnerToUpdate.ContactPerson = partner.ContactPerson;
                partnerToUpdate.ContactNumber = partner.ContactNumber;
                unitOfWork.partnerRepository.Update(partnerToUpdate);
            }
            return unitOfWork.Complete();
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

        public IEnumerable<Partner> GetEmployerPartners()
        {
            return unitOfWork.partnerRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public TableResponse GetEmployerPartnersTable(TableRequest tableRequest)
        {
            TableResponse tableResponse = new TableResponse();

            var query = unitOfWork.partnerRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<Partner> filterTemplate = FilterFactory<Partner>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }

        public IEnumerable<PricingListItem> GetEmployersPricingListItems()
        {
            return unitOfWork.pricingListRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public TableResponse GetEmployersPricingListItemsTable(TableRequest tableRequest)
        {
            TableResponse tableResponse = new TableResponse();

            var query = unitOfWork.pricingListRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<PricingListItem> filterTemplate = FilterFactory<PricingListItem>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }
    }
}
