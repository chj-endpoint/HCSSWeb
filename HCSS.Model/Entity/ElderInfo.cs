using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCSS.Model.Entity
{
    
    /// <summary>
    /// 老人信息表
    /// </summary>
    public class ElderInfo : BaseEntity
    {
        /// <summary>
        /// 名字
        /// </summary>
        [StringLength(20)]
        [Required]
        public string name { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [StringLength(50)]
        [Required]
        public string street { get; set; }

        /// <summary>
        /// 社区
        /// </summary>
        [StringLength(50)]
        [Required]
        public string community { get; set; }

        /// <summary>
        /// 小区
        /// </summary>
        [StringLength(50)]
        [Required]
        public string village { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string extInfo { get; set; }
    }
}