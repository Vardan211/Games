using System.Collections.Generic;
using System.Threading.Tasks;
using Games.DataAcess.Entities;
using Games.Domain.Models;

namespace Games.Domain.Interfaces
{
    public interface IGameService
    {
        Task<List<GameEntity>> GetAll();
        Task Delete(int id);
        Task Update(GameEntity game);
        Task AddReview(ReviewAddModel review);
        Task Add(GameAddModel game);
        Task<List<GameSortModel>> GamesSortByRatingDescending();
        Task<ReviewsOfGameModel> GetAllReviewsOfGame(int gameId);
    }
}
