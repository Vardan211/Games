using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Models
{
     public class ReviewAddModel
    {
        public int GameId { get; set; }
        public string? ReviewText { get; set; }

        [RegularExpression(@"^([1-9]|10)$")]
        public int Rating { get; set; }
    }
}
