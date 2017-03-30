using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LLY.LifeTask.Model.Life;

namespace LLY.LifeTask.Model.EntityFramework.Life.Map
{
    public class SaleOrderMap
    {
        public static void Map(EntityTypeBuilder<SaleOrder> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .ValueGeneratedNever();

            builder.Property(t => t.OrderNo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.ConsigneeName)
                .HasMaxLength(20);

            builder.Property(t => t.ConsigneeMobile)
                .HasMaxLength(15);

            builder.Property(t => t.ConsigneeAddress)
                .HasMaxLength(500);

            builder.Property(t => t.ConsigneeFullAddress)
                .HasMaxLength(500);

            builder.Property(t => t.Remarks)
                .HasMaxLength(2000);

            builder.Property(t => t.InvoiceTitle)
                .HasMaxLength(500);

            builder.Property(t => t.CreatedUser)
                .HasMaxLength(100);

            builder.Property(t => t.CreatedTerminal)
                .HasMaxLength(50);

            builder.Property(t => t.LastModifiedUser)
                .HasMaxLength(100);

            builder.Property(t => t.LastModifiedTerminal)
                .HasMaxLength(50);

            builder.Property(t => t.BuyerMemo)
                .HasMaxLength(500);

            builder.Property(t => t.ApplicationCode)
                .HasMaxLength(50);

            builder.Property(t => t.ExternalAppCode)
                .HasMaxLength(50);

            builder.Property(t => t.ApplicationVersion)
                .HasMaxLength(50);

            builder.Property(t => t.ApplicationChannel)
                .HasMaxLength(50);

            builder.Property(t => t.IdCardNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("SaleOrders");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.OrderNo).HasColumnName("OrderNo");
            builder.Property(t => t.ProductAmount).HasColumnName("ProductAmount");
            builder.Property(t => t.PerferntialAmount).HasColumnName("PerferntialAmount");
            builder.Property(t => t.LianCoinDeduct).HasColumnName("LianCoinDeduct");
            builder.Property(t => t.WelfareLianCoinAmount).HasColumnName("WelfareLianCoinAmount");
            builder.Property(t => t.WelfareLianCoinActual).HasColumnName("WelfareLianCoinActual");
            builder.Property(t => t.OrderFreight).HasColumnName("OrderFreight");
            builder.Property(t => t.OrderAmount).HasColumnName("OrderAmount");
            builder.Property(t => t.ReceivableAmount).HasColumnName("ReceivableAmount");
            builder.Property(t => t.PayableAmount).HasColumnName("PayableAmount");
            builder.Property(t => t.RealIncomeAmount).HasColumnName("RealIncomeAmount");
            builder.Property(t => t.OrderPerferntial).HasColumnName("OrderPerferntial");
            builder.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            builder.Property(t => t.ShipStatus).HasColumnName("ShipStatus");
            builder.Property(t => t.PayStatus).HasColumnName("PayStatus");
            builder.Property(t => t.PaymentTerms).HasColumnName("PaymentTerms");
            builder.Property(t => t.PayedAt).HasColumnName("PayedAt");
            builder.Property(t => t.SupplierId).HasColumnName("SupplierId");
            builder.Property(t => t.ConsigneeName).HasColumnName("ConsigneeName");
            builder.Property(t => t.ConsigneeMobile).HasColumnName("ConsigneeMobile");
            builder.Property(t => t.ConsigneeAddress).HasColumnName("ConsigneeAddress");
            builder.Property(t => t.ConsigneeFullAddress).HasColumnName("ConsigneeFullAddress");
            builder.Property(t => t.RegionId).HasColumnName("RegionId");
            builder.Property(t => t.MemberId).HasColumnName("MemberId");
            builder.Property(t => t.Remarks).HasColumnName("Remarks");
            builder.Property(t => t.SubmitAt).HasColumnName("SubmitAt");
            builder.Property(t => t.InvalidTime).HasColumnName("InvalidTime");
            builder.Property(t => t.IsPrintInvoice).HasColumnName("IsPrintInvoice");
            builder.Property(t => t.InvoiceType).HasColumnName("InvoiceType");
            builder.Property(t => t.InvoiceTitle).HasColumnName("InvoiceTitle");
            builder.Property(t => t.ReferenceId).HasColumnName("ReferenceId");
            builder.Property(t => t.CustomerServiceType).HasColumnName("CustomerServiceType");
            builder.Property(t => t.IsRejected).HasColumnName("IsRejected");
            builder.Property(t => t.SignedAt).HasColumnName("SignedAt");
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            builder.Property(t => t.CreatedTerminal).HasColumnName("CreatedTerminal");
            builder.Property(t => t.LastModifiedAt).HasColumnName("LastModifiedAt");
            builder.Property(t => t.LastModifiedUser).HasColumnName("LastModifiedUser");
            builder.Property(t => t.LastModifiedTerminal).HasColumnName("LastModifiedTerminal");
            builder.Property(t => t.RejectedAt).HasColumnName("RejectedAt");
            builder.Property(t => t.BuyerMemo).HasColumnName("BuyerMemo");
            builder.Property(t => t.SupplierFreight).HasColumnName("SupplierFreight");
            builder.Property(t => t.FreightLianCoinDeduct).HasColumnName("FreightLianCoinDeduct");
            builder.Property(t => t.PickedAt).HasColumnName("PickedAt");
            builder.Property(t => t.ShippedAt).HasColumnName("ShippedAt");
            builder.Property(t => t.AuditedAt).HasColumnName("AuditedAt");
            builder.Property(t => t.CancelledAt).HasColumnName("CancelledAt");
            builder.Property(t => t.CompletedAt).HasColumnName("CompletedAt");
            builder.Property(t => t.ApplicationCode).HasColumnName("ApplicationCode");
            builder.Property(t => t.SignInTime).HasColumnName("SignInTime");
            builder.Property(t => t.ExternalAppCode).HasColumnName("ExternalAppCode");
            builder.Property(t => t.ApplicationVersion).HasColumnName("ApplicationVersion");
            builder.Property(t => t.ApplicationChannel).HasColumnName("ApplicationChannel");
            builder.Property(t => t.IsCharge).HasColumnName("IsCharge");
            builder.Property(t => t.ChargeStatus).HasColumnName("ChargeStatus");
            builder.Property(t => t.ChargeTerms).HasColumnName("ChargeTerms");
            builder.Property(t => t.ChargeAt).HasColumnName("ChargeAt");
            builder.Property(t => t.IsOverseas).HasColumnName("IsOverseas");
            builder.Property(t => t.IdCardNo).HasColumnName("IdCardNo");
            builder.Property(t => t.DistributorId).HasColumnName("DistributorId");
            builder.Property(t => t.IsAutoProcess).HasColumnName("IsAutoProcess");
            builder.Property(t => t.IsGroupbuy).HasColumnName("IsGroupbuy");
        }
    }
}
