using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Domain.Common
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("dd:MM:yy HH:mm:ss");
        public string UpdatedAt { get; set; } = DateTime.UtcNow.ToString("dd:MM:yy HH:mm:ss");
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
