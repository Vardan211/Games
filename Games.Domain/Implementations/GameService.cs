using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.DataAcess.Abstractions;
using Games.DataAcess.Entities;
using Games.Domain.Interfaces;
using Games.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Games.Domain.Implementations
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<GameEntity> _games;
        private readonly IGenericRepository<ReviewEntity> _reviews;

        public GameService(IGenericRepository<GameEntity> games, IGenericRepository<ReviewEntity> reviews)
        {
            _games = games;
            _reviews = reviews;
        }
        
        public async Task Add(GameAddModel game)
        {
            var entity = new GameEntity
            {
                Name = game.Name,
                Genre = (int)game.Genre
            };

            await _games.Add(entity);
        }

        public async Task<List<GameEntity>> GetAll()
        {
            var games = _games.GetAll();
            return await games.ToListAsync();
        }

        public async Task Delete(int id)
        {
            await _games.Delete(id);
        }

        public async Task Update(GameEntity game)
        {
            await _games.Update(game);
        }

        public async Task AddReview(ReviewAddModel review)
        {
            var entity = new ReviewEntity
            {
                GameId = review.GameId,
                ReviewText = review.ReviewText,
                Rating = review.Rating,
            };

            await _reviews.Add(entity);
        }

        public async Task<List<GameSortModel>> GamesSortByRatingDescending()
        {
            var reviews = _reviews.GetAll().OrderByDescending(gme => gme.Rating).ToList();
            var results = new List<GameSortModel>();
            
            foreach (var gm in reviews)
            {
                var entity = await _games.Get(gm.GameId);
                var gameSortModel = new GameSortModel
                {
                  game = entity,
                  Rating = gm.Rating,           
                };
                
                results.Add(gameSortModel);
            }
            
            return  results;
        }

        public async Task<ReviewsOfGameModel> GetAllReviewsOfGame(int gameId)
        {
            var game = await _games.Get(gameId);
            var reviews = await _reviews.GetAll().Where(x => x.GameId == gameId).ToListAsync();

            return new ReviewsOfGameModel
            {
                Game = game,
                Reviews = reviews
            };
        }
    }
}
