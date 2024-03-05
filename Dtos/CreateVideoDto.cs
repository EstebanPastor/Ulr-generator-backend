using System.ComponentModel.DataAnnotations;

namespace server.Dtos
{
    public class CreateVideoDto
    {
        [MinLength(5)]
        public string Title { get; set; }
    }
}
