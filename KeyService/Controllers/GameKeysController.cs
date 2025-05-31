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

        [HttpPut("{id}/use")]
        public async Task<IActionResult> MarkGameKeyAsUsed(int id)
        {
            try
            {
                var updatedGameKey = await _gameKeyService.MarkAsUsedAsync(id);
                return Ok(updatedGameKey);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameKey(int id)
        {
            try
            {
                await _gameKeyService.DeleteKeyAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/unused")]
        public async Task<IActionResult> GetUnusedGameKeys()
        {
            var unusedKeys = await _gameKeyService.GetUnusedKeysAsync();
            return Ok(unusedKeys);
        }
        
        [HttpGet("/count")]
        public async Task<IActionResult> GetTotalGameKeysCount()
        {
            var gameKeys = await _gameKeyService.GetTotalKeysCountAsync();
            return Ok(gameKeys);
        }
    }
}