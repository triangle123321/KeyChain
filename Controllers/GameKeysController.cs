using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/gamekeys")]
    public class GameKeysController : ControllerBase
    {
        private readonly IGameKeyService _gameKeyService;
        public GameKeysController(IGameKeyService gameKeyService)
        {
            _gameKeyService = gameKeyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameKeys()
        {
            var gameKeys = await _gameKeyService.GetAllKeysAsync();
            return Ok(gameKeys);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameKeyById(int id)
        {
            try
            {
                var gameKey = await _gameKeyService.GetKeyAsync(id);
                return Ok(gameKey);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGameKey([FromBody] GameKey gameKey)
        {
            if (gameKey == null || string.IsNullOrWhiteSpace(gameKey.Key) || string.IsNullOrWhiteSpace(gameKey.GameTitle))
            {
                return BadRequest("Game key and title are required.");
            }

            try
            {
                var createdGameKey = await _gameKeyService.AddKeyAsync(gameKey.Key, gameKey.GameTitle, gameKey.Platform);
                return CreatedAtAction(nameof(GetGameKeyById), new { id = createdGameKey.Id }, createdGameKey);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("/count")]
        public async Task<IActionResult> GetTotalGameKeysCount()
        {
            var gameKeys = await _gameKeyService.GetTotalKeysCountAsync();
            return Ok(gameKeys);
        }
    }
}