using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.DTO.CustomerDto
{
    public class CustomerDto
    {
        public string CustomCode { get; set; }
        [ForeignKey("CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        public string CustomerType { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public double CreditLimit { get; set; }
        public double InvoiceTotal { get; set; }
        public double ReceivedAmount { get; set; }
        public DateTime LastInvoiceDate { get; set; }
        public double OverPayment { get; set; }
        public double CreditAmount { get; set; }
        public double ReturnAmount { get; set; }
        public double ChequeReturnAmount { get; set; }
        public int CreditDays { get; set; }
    }
}
