using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public string LongDesc { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        
        public byte[] Thumbnail { get; set; }
        [Required]
        public bool IsPopular { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
