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
        public async Task<IActionResult> GetTotalGameKeysCount()
        {
            var gameKeys = await _gameKeyService.GetTotalKeysCountAsync();
            return Ok(gameKeys);
        }

    }
}