using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adds.Entities
{
    public class Add
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Context { get; set; }

        //TODO author
    }
}
