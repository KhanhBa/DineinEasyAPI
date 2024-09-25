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

        public async Task<Supabase.Client> InitializeClient()
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("not found supabase url");

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("not found supabase key");

            var supabase =  new Supabase.Client(url, key, options);
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

    }
}

