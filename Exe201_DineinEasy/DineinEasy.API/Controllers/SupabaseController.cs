using DineinEasy.API.Supabase;
using DineinEasy.Data.OutServices;
using DineinEasy.Service.Responses;
using Microsoft.AspNetCore.Mvc;
using Supabase.Storage;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class SupabaseController : Controller
    {
        private readonly SupabaseHelp _supabaseHelper;
        public SupabaseController()
        {
            _supabaseHelper = new SupabaseHelp();
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

            var fileUrl = await SupabaseHelper.UploadFileToSupabase(image, bucket);
            if (fileUrl == null)
            {
                return StatusCode(500, new { message = "Failed to upload the file to Supabase" });
            }

            return Ok(new { Url = fileUrl });
        }
        [HttpGet("list-images/type/{id}")]
        public async Task<IActionResult> ListImages([FromRoute] int id)
        {
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

            if (string.IsNullOrEmpty(bucket))
                return BadRequest(new { message = "Invalid bucket type specified" });

            try
            {
                var fileUrls = await _supabaseHelper.ListFilesInBucket(bucket);
                return Ok(new { Urls = fileUrls });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Failed to retrieve files: {ex.Message}" });
            }
        }
    }
}
