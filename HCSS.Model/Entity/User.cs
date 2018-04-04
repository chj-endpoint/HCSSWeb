using System.ComponentModel.DataAnnotations;

namespace HCSS.Model.Entity
{
    /// <summary>
    ///用户表
    /// <summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(20)]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(20)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(15)]
        public string Phone { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
    }
}