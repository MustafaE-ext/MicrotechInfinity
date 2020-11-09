using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.DataAccess.DTOs
{
    /*
  Entities may be part of a business domain. 
  Thus, they can implement behavior and be applied to different use cases within the domain. 
  DTOs are used only to transfer data from one process or context to another.
 */
    public class PurchaseInvoice 
    {
        public string Code { set; get; }
        public DateTime Date { set; get; }
        public decimal? DiscountPercentage { set; get; }
        public string ContactsCode { set; get; }
        public string ContactsDescriptionValue { set; get; }
        public int? PrintCount { set; get; }

        public string Currency { set; get; }
        public decimal PDTotalValue { set; get; }
        public decimal PDDiscountValue { set; get; }
        public decimal PDNetTotalValue { set; get; }
        public decimal PDLinkedWriteOffValue { set; get; }
        public decimal PDDownPaymentValue { set; get; }
        public decimal PDDiscountAfterTaxesValue { set; get; }
        public decimal PDExpensesPaidBySupplier { set; get; }
        public decimal PDPromotionsValue { set; get; }
        public decimal PDAmountPaid { set; get; }
        public decimal PDToPayAmount { set; get; }
        public decimal PDExpensesNotPaidBySupplier { set; get; }
        public decimal PDReturnValue { set; get; }
        public decimal PDTaxValue { set; get; }
    }
}
