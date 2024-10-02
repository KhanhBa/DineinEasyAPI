using DineinEasy.API.Supabase;
using DineinEasy.Service.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class SupabaseController : Controller
    {
        public SupabaseController()
        {
        }

        [HttpPost("upload-image/type/{id}")]
        public async Task<IActionResult> UploadImage(IFormFile image, [FromRoute] int id)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded" });
            }
            var bucket = "";
            switch (id)
            {
                case 1:
                    bucket = "avatars";
                    break;
                case 2:
                    bucket = "restaurants";
                    break;
                case 3:
                    bucket = "reviews";
                    break;
            }
                
            var fileUrl = await SupabaseHelper.UploadFileToSupabase(image,bucket);
            if (fileUrl == null)
            {
                return StatusCode(500, new { message = "Failed to upload the file to Supabase" });
            }

            return Ok(new { Url = fileUrl });
        }
    }
}
