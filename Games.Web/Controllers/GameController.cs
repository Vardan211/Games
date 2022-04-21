using System.Threading.Tasks;
using Games.DataAcess.Entities;
using Games.Domain.Interfaces;
using Games.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Add a specific Game.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Game
        ///     {       
        ///        "name": "Game name",
        ///        "Genre": "1"
        ///     }
        ///     
        ///     1-Shooter
        ///     2-Strategy
        ///     3-Sandbox
        ///     4-MOBA 
        ///     5-RPG 
        ///     6-Sports
        ///     7-Puzzlers
        ///     8-Adventure
        ///     9-Survival
        ///     10-Horror
        ///     11-Platformer
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(GameAddModel game)
        {
            await _gameService.Add(game);
            return Ok();
        }
        
        /// <summary>
        /// Delete a specific Game.
        /// </summary>
        /// <param name="id"> Id of the game</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.Delete(id);
            return Ok();
        }
        
        /// <summary>
        /// Update game's information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GameEntity game)
        {
            await _gameService.Update(game);
            return Ok();
        }
        
        /// <summary>
        /// Sorting games in descending order
        /// </summary>
        /// <returns></returns>
        [HttpGet("sort-by-ratings-descending")]
        public  async Task<IActionResult> Sort()
        {
            var result =  await _gameService.GamesSortByRatingDescending();
            
            return Ok(result);
        }
        
        /// <summary>
        /// Getting all reviews of specific game
        /// </summary>
        /// <param name="id">Id of the game</param>
        /// <returns></returns>
        [HttpPost("get-all-reviews")]
        public async Task<IActionResult> GetAllReviews(int id)
        {
            var result =  await _gameService.GetAllReviewsOfGame(id);
            return Ok(result);
        }
        
        /// <summary>
        /// Add review
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview(ReviewAddModel review)
        {
            await _gameService.AddReview(review);
            return Ok();
        }
    }
}
