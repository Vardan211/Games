using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.DataAcess.Entities;

namespace Games.Domain.Models
{
    public class GameSortModel
    {
        public GameEntity game { get; set; }
        public int Rating { get; set; }
    }
}
