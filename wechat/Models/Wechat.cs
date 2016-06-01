﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wechat.Models
{
    public class Wechat
    {

    }

   

    public class WechatUser
    {
        public int WechatUserId { get; set; }

        
        [Required]
        [StringLength(50)]
        public string openid { get; set; }
        [StringLength(50)]
        public string nickname { get; set; }
      
        public int sex { get; set; }
        [StringLength(50)]
        public string province { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        [StringLength(500)]
        public string headimgurl { get; set; }
        
        public DateTime cctime { get; set; }
        [StringLength(50)]
        public string sourceid { get; set; }
        public ICollection<ActiveUpImg> ActiveUpImg { get; set; }

    }

    public class ActiveUpImg
    {
     public int ActiveUpImgId { get; set; }
      
        [StringLength(500)]
        public string mediaId { get; set; }
        [StringLength(500)]
        
        public string imgUrl { get; set; }
        
        public DateTime cctime { get; set; }

        public int WechatUserId { get; set; }

        public virtual WechatUser WechatUser { get; set; }
    }

    public class QuestionGuiTian
    {
        public int id { get; set; }
        public string openid { get; set; }
        public int q1 { get; set; }
        public int q2 { get; set; }
        public int q3 { get; set; }
        public int q4 { get; set; }
        public int q5 { get; set; }
        public DateTime  cctime { get; set; }

    }

    public class WechatDBContext : DbContext
    {
        public DbSet<WechatUser> WechatUsers { get; set; }
        public DbSet<ActiveUpImg> ActiveUpImgs { get; set; }
        public DbSet<QuestionGuiTian> QuestionGuiTians { get; set; }
        
    }
}
