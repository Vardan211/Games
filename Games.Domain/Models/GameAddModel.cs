using Games.DataAcess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Models
{
    public class GameAddModel
    {
        public string Name { get; set; }
        
        public GenreType Genre { get; set; }
    }
}
