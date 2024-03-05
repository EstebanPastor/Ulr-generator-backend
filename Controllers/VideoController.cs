using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Context;
using server.Dtos;
using server.Entities;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        // Access to the DB

        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Video>> CreateNewVideo([FromBody] CreateVideoDto dto)
        {
            var newVideo = new Video()

            {
                Title = dto.Title,
                Url = CreateUniqueUrl(),
            };
            await _context.Videos.AddAsync(newVideo);
            await _context.SaveChangesAsync();

            return Ok(newVideo);
        }

        // Unique url generator

        private string CreateUniqueUrl()
        {
            var newRandomUrl = string.Empty;

            Random rand = new Random();

            var boolFlag = true;

            while (boolFlag)
            {
                newRandomUrl = "";

                for (int i = 0; i < 10; i++)
                {
                    var randomNum = rand.Next(1, 9);
                    var randomChar = (char)rand.Next('a', 'z');
                    newRandomUrl += randomChar.ToString();
                    newRandomUrl += randomNum.ToString();
                }

                var isDuplicate = _context.Videos.Any(q => q.Url == newRandomUrl);

                if (!isDuplicate)
                {
                    boolFlag = false;
                }
            }

            return newRandomUrl;
        }
    }
}
