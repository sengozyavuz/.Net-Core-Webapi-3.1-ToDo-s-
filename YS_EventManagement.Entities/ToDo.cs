using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace YS_EventManagement.Entities
{
    public class ToDo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ToDo Date")]
        public DateTime ToDoDate { get; set; }


        [StringLength(100)]
        public string Description { get; set; }



    }
}
