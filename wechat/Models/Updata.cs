using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wechat.Models
{
  public  class Updata
    {
        public int id { get; set; }
        [StringLength(50)]
        public string openid { get; set; }
        [StringLength(50)]
        public string activeName { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
        public int? fee { get; set; }
        [StringLength(50)]
        public string  ISP { get; set; }
        public DateTime cctime { get; set; }
    }
}
