using System.Collections.Generic;
using Games.DataAcess.Entities;

namespace Games.Domain.Models
{
    public class ReviewsOfGameModel
    {
        public GameEntity Game { get; set; }
        public List<ReviewEntity> Reviews { get; set; }
    }
}