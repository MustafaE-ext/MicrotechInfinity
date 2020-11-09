using System;
using System.Collections.Generic;
//k
namespace MicrotechInfinity.DataAccess.Queries
{
    public class QPurchaseInvoiceDetail:ILoadEntityItems
    {
        static public List<MDPurchaseInvoiceDetail> LoadEntityItems(Int64 startRow, Int64 countRows,
                               List<NameValuePair<string, string>> colSort, List<NameValuePair<string, string>> colFilter, out Int64 totalRows)
        {
            //We use aliases to be able to correctly map properties to DB fields
            const string Query = "SELECT DISTINCT PurchaseInvoiceDetails.Id AS Id, Item.Id as ItemId, Item.Code As DocumentItem, [Item].[Description.Value]  AS ItemName, PostComponents," +
             "ItemAttributesMatrix.Id as ItemAttributesId, ItemAttributesMatrix.[SerialCombinationDescription.Value] AS ItemAttributeDescription, [ItemWarehouse.Id] AS WarehouseId," +
             "Warehouse.[Description.Value] AS WarehouseDescription, WarehouseItemDetailsItemLocation.Id AS IssueLocationId, WarehouseItemDetailsItemLocation.IssueLocationDescription As IssueLocationDescription," +
             "[ItemWarehouseLocation.Id] As WarehouseLocationId, WarehouseLocation.[Description.Value] AS WarehouseLocationDescription," +
             "Lot.Id AS LotId, Lot.Number AS LotNumber," +
             "Project.Id AS ProjectId, Project.[Name.Value] AS ProjectName," +
             "ProductionDate, PurchaseInvoiceDetails.ExpiryDate," +
             "UOM.Id AS ItemUOMId, UOM.[Description.Value] AS ItemUOMDescription, Quantity, [SecondUOM.Id] AS SecondUOMId, SecondQuantity, PriceBase, PriceHome, PriceLocal, DiscountPercentage, DiscountBase, DiscountHome, DiscountLocal," +
             "PromotionDiscountBase, PromotionDiscountHome, PromotionDiscountLocal, DetailedExpensesBase, DetailedExpensesHome, DetailedExpensesLocal, DetailedTaxBase, DetailedTaxHome, DetailedTaxLocal, NetBase, NetHome, NetLocal," +
             "[ItemAccount.Id] As ItemAccountId, [DiscountAccount.Id] as DiscountAccountId" +
             " FROM PurchaseInvoiceDetails" +
              " LEFT OUTER JOIN Item on PurchaseInvoiceDetails.[DocumentItem.Id] = Item.Id" +
              " LEFT OUTER JOIN ItemAttributesMatrix on ItemAttributesMatrix.[_Item.Id] = Item.Id" +
              " LEFT OUTER JOIN Warehouse on Warehouse.id = PurchaseInvoiceDetails.[ItemWarehouse.Id]" +
              " LEFT OUTER JOIN WarehouseItemDetailsItemLocation on WarehouseItemDetailsItemLocation.Id = [IssueLocation.Id]" +
              " LEFT OUTER JOIN WarehouseLocation on Warehouselocation.Id = [ItemWarehouseLocation.Id]" +
              " LEFT OUTER JOIN Lot on Lot.Id = PurchaseInvoiceDetails.[Lot.Id]" +
              " LEFT OUTER JOIN Project on Project.Id = PurchaseInvoiceDetails.[Project.Id]" +
              " LEFT OUTER JOIN UOM on UOM.Id = [ItemUOM.Id]";

            var docid = colFilter.FirstOrDefault(x => x.Name.StartsWith("docid"));
            if (docid != null && !string.IsNullOrEmpty(docid.Value))
            {
                //we must hide db fields from the UI for security, we use an alias.
                docid.Name = "PurchaseInvoiceDetails.[Parent.Id]";
            }

            string Where = FormatFilters(colFilter);
            string Order = FormatSort(colSort);

            string paginationQuery = string.IsNullOrEmpty(Order) ?
                string.Format(" ORDER BY PurchaseInvoiceDetails.Id OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", startRow, countRows) :
                Order + string.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", startRow, countRows);

            string countQuery = "SELECT count(*) FROM PurchaseInvoiceDetails" +
              " LEFT OUTER JOIN Item on PurchaseInvoiceDetails.[DocumentItem.Id] = Item.Id" +
             " LEFT OUTER JOIN ItemAttributesMatrix on ItemAttributesMatrix.[_Item.Id] = Item.Id" +
             " LEFT OUTER JOIN Warehouse on Warehouse.id = PurchaseInvoiceDetails.[ItemWarehouse.Id]" +
             " LEFT OUTER JOIN WarehouseItemDetailsItemLocation on WarehouseItemDetailsItemLocation.Id != [IssueLocation.Id]" +
             " LEFT OUTER JOIN WarehouseLocation on Warehouselocation.Id = [ItemWarehouseLocation.Id]" +
             " LEFT OUTER JOIN Lot on Lot.Id = PurchaseInvoiceDetails.[Lot.Id]" +
             " LEFT OUTER JOIN Project on Project.Id = PurchaseInvoiceDetails.[Project.Id]" +
             " LEFT OUTER JOIN UOM on UOM.Id = [ItemUOM.Id]" + Where;


            return MD_EntityLoader.LoadEntitiesWithPagination<MDPurchaseInvoiceDetail>(Query + Where + paginationQuery, countQuery, out totalRows, false);
        }
    }
}
