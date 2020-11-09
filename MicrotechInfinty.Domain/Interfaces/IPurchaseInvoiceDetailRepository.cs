using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Domain.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Domain.Interfaces
{
    public interface IPurchaseInvoiceDetailRepository :
          IReadRepository<MDPurchaseInvoiceDetail, int>, ICreateRepository<MDPurchaseInvoiceDetail>, IUpdateRepository<MDPurchaseInvoiceDetail>, IRemoveRepository<int>,
          IGetPageItems<MDPurchaseInvoiceDetail>
    {
    }
}
