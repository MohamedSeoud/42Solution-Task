using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Models
{
    [Table("FinanceRequest", Schema = "dbo")]
    public class FinanceRequest
    {
        [Key]
        [Required]
        public int RequestNumber { set; get; }
        public int PaymentAmount { set; get; }
        public int PaymentPeriod { set; get; }
        public int TotalProfit { set; get; }
        public int RequestStatus { set; get; }
    }
}
