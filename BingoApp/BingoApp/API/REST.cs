using BingoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.API
{
    class REST
    {
        public static string BASE_URL = "http://www.hyeumine.com/";
        public static string GETCARD_URL = "getcard.php?bcode=";
        public static string CHECKWIN_URL = "checkwin.php?playcard_token=";
        private static HttpClient client = null;

        public static async Task<User> GetPlayer(string token)
        {
            var restCall = await RestCall.GetAsync(BASE_URL + GETCARD_URL + token);
            var reqString = restCall.Content.ReadAsStringAsync();
            var jsonobj = reqString.Result;
            var playerObj = JsonConvert.DeserializeObject<User>(jsonobj);

            return playerObj;
        }

        public static async Task<int> SubmitCard(string token)
        {
            var res = await RestCall.GetAsync(BASE_URL + CHECKWIN_URL + token);
            var resString = res.Content.ReadAsStringAsync();
            int status = Int32.Parse(resString.Result);

            return status;
        }
        public static HttpClient RestCall
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                }
                return client;
            }
            set { }
        }

    }
}
