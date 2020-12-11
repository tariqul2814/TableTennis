using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TableTennis.DataAccess.Entities.Common
{
    public class AuditEntity
    {
        public DateTime CreateDate { get; set; }
        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [StringLength(200)]
        public string ModifiedBy { get; set; }
        public bool IsRemove { get; set; }
    }
}
