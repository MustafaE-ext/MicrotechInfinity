using Core.Model.Queries;
using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Domain.Interfaces;
using MicrotechInfinity.Helper.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MicrotechInfinity.DataAccess
{
    public class PurchaseInvoiceRepository : Repository, IPurchaseInvoiceRepository
    {
        public PurchaseInvoiceRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public Task<int> AddAsync(MDPurchaseInvoice entity)
        {
            throw new NotImplementedException();
        }

        //private readonly IConfiguration configuration;
        //public PurchaseInvoiceRepository(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        //public Task<int> AddAsync(MDPurchaseInvoice entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IReadOnlyList<MDPurchaseInvoice>> GetAllAsync()
        //{
        //    //var sql = "SELECT * FROM PurchaseInvoice";
        //    //using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    //{
        //    //    connection.Open();
        //    //    var result = await connection.QueryAsync<PurchaseInvoice>(sql);

        //    //    return result.ToList();
        //    //}
        //    return null;
        //}

        //public Task<MDPurchaseInvoice> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> UpdateAsync(MDPurchaseInvoice entity)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MDPurchaseInvoice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MDPurchaseInvoice> GetByIdAsync(int id)
        {
            var t = new MDPurchaseInvoice();
            return null; 
        }

        public IEnumerable<MDPurchaseInvoice> GetPage(long startRow, long countRows, IEnumerable<NameValuePair<string, string>> colSort, IEnumerable<NameValuePair<string, string>> colFilter, out long totalRows)
        {
            return QPurchaseInvoice.LoadEntities(startRow, countRows, colSort, colFilter, out totalRows);
        }

        public Task<int> UpdateAsync(MDPurchaseInvoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
