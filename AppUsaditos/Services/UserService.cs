using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using AppUsaditos.Model;
using Firebase.Database.Query;


namespace AppUsaditos.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://appusaditos-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<Users>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }
        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if(await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new Users()
                    {
                        Username = uname,
                        Password = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user=(await client.Child("Users")
                .OnceAsync<Users>()).Where(u =>u.Object.Username==uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }
}
