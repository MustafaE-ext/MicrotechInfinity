using MicrotechInfinity.Domain.Interfaces;
using MicrotechInfinity.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MicrotechInfinity.DataAccess.UoW
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
       
        public IPurchaseInvoiceRepository PurchaseInvoiceRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {

            PurchaseInvoiceRepository = new PurchaseInvoiceRepository(context, transaction);
      
        }
    }
}
