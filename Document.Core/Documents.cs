using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Document.Core
{
    [Index( nameof(DocumentTitle), IsUnique = true)]
    public class Documents
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [StringLength(200)]
        public string DocumentTitle { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The Describtion is required")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [StringLength(200)]
        public string DocumentURL { get; set; }



    }
}
