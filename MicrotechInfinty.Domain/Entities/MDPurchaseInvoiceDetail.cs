using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Domain.Entities
{
    public class MDPurchaseInvoiceDetail : MDEntity
    {
        public Guid ItemId { set; get; }
        public string DocumentItem { set; get; }
        public string ItemName { set; get; }
        public bool PostComponents { set; get; }
        public Guid ItemAttributesId { set; get; }
        public string ItemAttributeDescription { set; get; }
        public Guid WarehouseId { set; get; }
        public string WarehouseDescription { set; get; }
        public Guid IssueLocationId { set; get; }
        public string IssueLocationDescription { set; get; }
        public Guid WarehouseLocationId { set; get; }
        public string WarehouseLocationDescription { set; get; }
        public Guid LotId { set; get; }
        public string LotNumber { set; get; }
        public Guid ProjectId { set; get; }
        public string ProjectName { set; get; }
        public DateTime ProductionDate { set; get; }
        public DateTime ExpiryDate { set; get; }
        public Guid ItemUOMId { set; get; }
        public string ItemUOMDescription { set; get; }
        public decimal Quantity { set; get; }
        public Guid SecondUOMId { set; get; }
        public decimal? SecondQuantity { set; get; }
        public decimal? PriceBase { set; get; }
        public decimal? PriceHome { set; get; }
        public decimal? PriceLocal { set; get; }
        public decimal? DiscountPercentage { set; get; }
        public decimal? DiscountBase { set; get; }
        public decimal? DiscountHome { set; get; }
        public decimal? DiscountLocal { set; get; }
        public decimal? PromotionDiscountBase { set; get; }
        public decimal? PromotionDiscountHome { set; get; }
        public decimal? PromotionDiscountLocal { set; get; }
        public decimal? DetailedExpensesBase { set; get; }
        public decimal? DetailedExpensesHome { set; get; }
        public decimal? DetailedExpensesLocal { set; get; }
        public decimal? DetailedTaxBase { set; get; }
        public decimal? DetailedTaxHome { set; get; }
        public decimal? DetailedTaxLocal { set; get; }
        public decimal? NetBase { set; get; }
        public decimal? NetHome { set; get; }
        public decimal? NetLocal { set; get; }
        public Guid ItemAccount { set; get; }
        public Guid DiscountAccount { set; get; }
    }
}
