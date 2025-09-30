using ERP_API.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Domain.Models
{
    public class CustomerType:BaseModel
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        public double InvoiceAmount { get; set; }

    }
}
