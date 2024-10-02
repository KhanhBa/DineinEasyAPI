using DineinEasy.Data.OutServices;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.API.Supabase
{
    public static class SupabaseHelper
    {
        public static async Task<string> UploadFileToSupabase(IFormFile image, string bucketName)
        {
            try
            {
                var supabaseHelper = new SupabaseHelp();

                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    var randomFileName = $"{IntToRandomBaseString(8)}"+Path.GetExtension(image.FileName);
                    return await supabaseHelper.UploadFile(fileBytes, randomFileName, bucketName);
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        public static string IntToRandomBaseString(int maxLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < maxLength; i++)
            {
                int index = random.Next(chars.Length);
                result.Append(chars[index]);
            }

            return result.ToString();
        }
    }
}
