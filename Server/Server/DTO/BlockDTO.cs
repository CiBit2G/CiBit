using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class BlockDTO
    {
        [Key]
        public int BlockId { get; set; }
        [Required]
        public int Length { get; set; }
    }
}
