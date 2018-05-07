using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace HCSS.Model.Entity
{

    /// <summary>
    /// DB表基础属性
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updateTime { get; set; }
    }
}