using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLY.LifeTask.Model.Life
{
    public partial class SaleOrder
    {
        [Key]
        public long Id { get; set; }
        public string OrderNo { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal PerferntialAmount { get; set; }
        public decimal LianCoinDeduct { get; set; }
        public decimal WelfareLianCoinAmount { get; set; }
        public decimal WelfareLianCoinActual { get; set; }
        public decimal OrderFreight { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal ReceivableAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public decimal RealIncomeAmount { get; set; }
        public Nullable<long> OrderPerferntial { get; set; }
        public int OrderStatus { get; set; }
        public Nullable<int> ShipStatus { get; set; }
        public Nullable<int> PayStatus { get; set; }
        public Nullable<long> PaymentTerms { get; set; }
        public Nullable<System.DateTime> PayedAt { get; set; }
        public long SupplierId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeMobile { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ConsigneeFullAddress { get; set; }
        public Nullable<long> RegionId { get; set; }
        public long MemberId { get; set; }
        public string Remarks { get; set; }
        public System.DateTime SubmitAt { get; set; }
        public int InvalidTime { get; set; }
        public bool IsPrintInvoice { get; set; }
        public Nullable<int> InvoiceType { get; set; }
        public string InvoiceTitle { get; set; }
        public Nullable<long> ReferenceId { get; set; }
        public Nullable<int> CustomerServiceType { get; set; }
        public Nullable<bool> IsRejected { get; set; }
        public Nullable<System.DateTime> SignedAt { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedUser { get; set; }
        public string CreatedTerminal { get; set; }
        public Nullable<System.DateTime> LastModifiedAt { get; set; }
        public string LastModifiedUser { get; set; }
        public string LastModifiedTerminal { get; set; }
        public Nullable<System.DateTime> RejectedAt { get; set; }
        public string BuyerMemo { get; set; }
        public decimal SupplierFreight { get; set; }
        public decimal FreightLianCoinDeduct { get; set; }
        public Nullable<System.DateTime> PickedAt { get; set; }
        public Nullable<System.DateTime> ShippedAt { get; set; }
        public Nullable<System.DateTime> AuditedAt { get; set; }
        public Nullable<System.DateTime> CancelledAt { get; set; }
        public Nullable<System.DateTime> CompletedAt { get; set; }
        public string ApplicationCode { get; set; }
        public int SignInTime { get; set; }
        public string ExternalAppCode { get; set; }
        public string ApplicationVersion { get; set; }
        public string ApplicationChannel { get; set; }
        public bool IsCharge { get; set; }
        public Nullable<int> ChargeStatus { get; set; }
        public Nullable<int> ChargeTerms { get; set; }
        public Nullable<System.DateTime> ChargeAt { get; set; }
        public bool IsOverseas { get; set; }
        public string IdCardNo { get; set; }
        public Nullable<long> DistributorId { get; set; }
        public bool IsAutoProcess { get; set; }
        public bool IsGroupbuy { get; set; }

    }
}
