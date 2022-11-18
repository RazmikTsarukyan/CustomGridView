using Microsoft.AspNetCore.Http;

namespace CustomGridView.MVC.Models
{
    public class UpdatePlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public int StatusId { get; set; }
        public IFormFile Image { get; set; }
    }
}
