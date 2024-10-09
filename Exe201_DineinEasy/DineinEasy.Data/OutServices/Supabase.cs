using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.OutServices
{
    public  class SupabaseHelp
    {
        string url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        string key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
        
        SupabaseOptions options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };
        
        Supabase.Client supabase;
        public SupabaseHelp()
        {
               
        }

        private async Task EnsureInitialized()
        {
            if (supabase == null)
            {
                supabase = await InitializeClient();
            }
        }


        public async Task<Supabase.Client> InitializeClient()
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("not found supabase url");

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("not found supabase key");

            var supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();
            return supabase;
        }
        public async Task<(bool, string)> SignIn(string email, string password)
        {

           if (string.IsNullOrEmpty(password)) return (false, "password is empty.");

            if (string.IsNullOrEmpty(email)) return (false, "email is empty.");

            supabase = await  this.InitializeClient();

            var authResponse = await supabase.Auth.SignInWithPassword(email, password);

            if (authResponse != null)
            {
                return (false, null);   
            }

            return (true, authResponse.AccessToken);
        }
        
        public async Task<string> UploadFile(byte[] fileBytes, string fileName, string bucket)
        {
            if (fileBytes == null || fileBytes.Length == 0) throw new ArgumentNullException("File bytes are empty.");
            if (string.IsNullOrEmpty(bucket)) throw new ArgumentNullException("Bucket name is empty.");

            await EnsureInitialized();
            var storage = supabase.Storage;
            var bucketClient = storage.From(bucket);

            try
            {
                var response = await bucketClient.Upload(fileBytes, fileName);
                if (!string.IsNullOrEmpty(response))
                {
                    return $"{url}/storage/v1/object/public/{bucket}/{fileName}";
                }
                else
                {
                    throw new Exception("File upload failed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to upload file: {ex.Message}");
            }
        }
        public async Task<List<string>> ListFilesInBucket(string bucketName)
        {
            if (string.IsNullOrEmpty(bucketName))
                throw new ArgumentException("Bucket name cannot be empty", nameof(bucketName));

            await EnsureInitialized();
            var storage = supabase.Storage;
            var bucketClient = storage.From(bucketName);

            try
            {
                var files = await bucketClient.List();
                var fileUrls = new List<string>();

                foreach (var file in files)
                {
                    var fileUrl = $"{url}/storage/v1/object/public/{bucketName}/{file.Name}";
                    fileUrls.Add(fileUrl);
                }

                return fileUrls;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list files in bucket: {ex.Message}");
            }
        }
    }
}

