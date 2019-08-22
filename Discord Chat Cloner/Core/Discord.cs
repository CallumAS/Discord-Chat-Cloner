using Discord_Chat_Cloner.Core.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Discord_Chat_Cloner.Core
{
    public class Discord
    {
        private readonly HttpClient _client;
        private const string _baseUrl = "https://discordapp.com/";
        public Discord(string authorizationToken)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", authorizationToken);
        }
        private async Task<string> SendRequest(string path)
        {
            int retries = 0;
            while (retries < 10)
            {
                try
                {
                    return await _client.GetStringAsync($"{_baseUrl}{path}");
                }
                catch
                {
                    retries++;
                }
            }
            return "[]";
        }
        public async Task<List<Message>> GetMessagesAsync(string channelId, int limit = 100, ulong? before = null)
        {
            string path = $"api/v6/channels/{channelId}/messages?limit={limit}";
            if (before.HasValue)
            {
                path += $"&before={before.Value}";
            }
            return JsonConvert.DeserializeObject<List<Message>>(await SendRequest(path));
        }
    }
}
