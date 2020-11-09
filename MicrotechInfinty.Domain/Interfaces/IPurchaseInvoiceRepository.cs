using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Domain.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Domain.Interfaces
{
    public interface IPurchaseInvoiceRepository:  
        IReadRepository<MDPurchaseInvoice, int>, ICreateRepository<MDPurchaseInvoice>, IUpdateRepository<MDPurchaseInvoice>, IRemoveRepository<int>,
        IGetPage<MDPurchaseInvoice>
    {
    }
}
