using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ToDoTask
    {
        #region Constants
        public const int NameLength = 50;
        #endregion
        #region Properties
        [Key]
        public int TaskID { get; set; }
        [Required]
        [StringLength(NameLength)]
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }

        #endregion
        #region Associations
        [ForeignKey("FKUserID")]
        public User Users { get; set; }
        public int FKUserID { get; set; }
        #endregion
    }
}
