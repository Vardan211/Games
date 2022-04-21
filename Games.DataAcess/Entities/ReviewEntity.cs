using System.ComponentModel.DataAnnotations;

namespace Games.DataAcess.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public int GameId {get; set;}
        public string? ReviewText { get; set;}
        [RegularExpression(@"'/^[1-10]+$/'")]
        public int Rating { get; set; }      
    }
}
