using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wechat.Models
{
   public class GGK
    {
        public int id { get; set; }

        [StringLength(50)]
        public string openid { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
        [StringLength(500)]
        public string addr { get; set; }
        [StringLength(50)]
        public string prize { get; set; }
        [StringLength(500)]
        public string actname { get; set; }
        public int? flag { get; set; }
        public DateTime cctime { get; set; }

    }
}
