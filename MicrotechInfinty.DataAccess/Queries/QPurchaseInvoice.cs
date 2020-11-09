using Core.Model.DTOs;
using Core.ORM;
using Core.Utils;
using Microsoft.Extensions.Configuration;
using MicrotechInfinity.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Model.Queries
{
 

    public class QPurchaseInvoice:ILoadEntities
    {

        static public List<MDPurchaseInvoice> LoadEntities(Int64 startRow, Int64 countRows,
                        List<NameValuePair<string, string>> colSort, List<NameValuePair<string, string>> colFilter, out Int64 totalRows)
        {
            /////////////////////////////////////////
            /// For other pages: change this query
            //We use aliases to be able to correctly map properties to DB fields
            const string Query = "SELECT DISTINCT PurchaseInvoice.Id AS Id, PurchaseInvoice.Code AS Code, PurchaseInvoice.Date AS Date, Contacts.code AS ContactsCode," +
                "Contacts.[Description.Value] AS ContactsDescriptionValue, DiscountPercentage, PrintCount, Currency.[Name.Value] AS Currency," +
                "[PaymentDetails.TotalValue] AS PDTotalValue , [PaymentDetails.DiscountValue] AS PDDiscountValue," +
				"[PaymentDetails.NetTotalValue] AS PDNetTotalValue, [PaymentDetails.LinkedWriteOffValue] AS PDLinkedWriteOffValue," +
				"[PaymentDetails.DownPaymentValue] AS PDDownPaymentValue, [PaymentDetails.DiscountAfterTaxesValue] AS PDDiscountAfterTaxesValue,"+
				"[PaymentDetails.ExpensesPaidBySupplier] AS PDExpensesPaidBySupplier, [PaymentDetails.PromotionsValue] AS PDPromotionsValue," +
				"[PaymentDetails.AmountPaid] AS PDAmountPaid, [PaymentDetails.ToPayAmount] AS PDToPayAmount," +
				"[PaymentDetails.ExpensesNotPaidBySupplier] AS PDExpensesNotPaidBySupplier, [PaymentDetails.ReturnValue] AS PDReturnValue," +
				"[PaymentDetails.TaxValue] AS PDTaxValue" +
                " FROM PurchaseInvoice" +
                " LEFT OUTER JOIN contacts on[Contact.Id] = Contacts.Id" +
                " LEFT OUTER JOIN Currency on Currency.Id = PurchaseInvoice.[Currency.Id]";
            //////////////////////////////////////////////////////////

            string Where = FormatFilters(colFilter);
            string Order = FormatSort(colSort);

            string paginationQuery = string.IsNullOrEmpty(Order) ?
                string.Format(" ORDER BY Id OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", startRow, countRows) :
                Order + string.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", startRow, countRows);


            /////////////////////////////////////////
            /// For other pages: change this query
            string countQuery = "SELECT count(*) FROM PurchaseInvoice" +
                  " LEFT OUTER JOIN contacts on [Contact.Id] = Contacts.Id" +
                  " LEFT OUTER JOIN Currency on Currency.Id = PurchaseInvoice.[Currency.Id]"+ Where;
            /////////////////////////////////////////

            return MD_EntityLoader.LoadEntitiesWithPagination<MDPurchaseInvoice>(Query + Where + paginationQuery, countQuery, out totalRows, false);
        }


       
    }
}
