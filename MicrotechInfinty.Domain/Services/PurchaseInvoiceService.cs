using MicrotechInfinity.Domain;
using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Domain.Interfaces;
using MicrotechInfinity.Domain.Interfaces.UoW;
using MicrotechInfinity.Helper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Services
{
    public class PurchaseInvoiceService:IPurchaseInvoiceService
    {
        private readonly IPurchaseInvoiceRepository _repository;
        private IUnitOfWork _unitOfWork;
        public PurchaseInvoiceService(IPurchaseInvoiceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddAsync(MDPurchaseInvoice entity)
        {
            throw new NotImplementedException();
        }

        //Logic
        public IEnumerable<MDPurchaseInvoice> ApplyTax()
        {
            //ApplyTax percentage for specific Invoide
            return this._repository.GetAllAsync().Result.Select(x => x.ApplyTaxFor());
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Foo()
        {
            using (var context = _unitOfWork.Create())
            {
            }
        }

        public Task<IReadOnlyList<MDPurchaseInvoice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MDPurchaseInvoice> GetByIdAsync(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                return  (await context.Repositories.PurchaseInvoiceRepository.GetByIdAsync(id));       
            }
        }

        public async Task<IEnumerable<MDPurchaseInvoice>> GetPage(long startRow, long countRows, IEnumerable<NameValuePair<string, string>> colSort, IEnumerable<NameValuePair<string, string>> colFilter, out long totalRows)
        {
            return await _repository.GetPage(startRow, countRows, colSort, colFilter, out totalRows);
        }

  

        public Task<int> UpdateAsync(MDPurchaseInvoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
