﻿using Google.Apis.Json;
using Google.Apis.Util.Store;
using MissionMattersRound2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MissionMattersRound2.Logic.Google_Implementations
{
    public class DataStore : IDataStore
    {
        public Task ClearAsync()
        {
            GoogleOauthTokenService.OauthToken = null;
            return Task.Delay(0);
        }

        public Task DeleteAsync<T>(string key)
        {
            GoogleOauthTokenService.OauthToken = null;
            return Task.Delay(0);
        }

        public Task<T> GetAsync<T>(string key)
        {
            var result = GoogleOauthTokenService.OauthToken;
            var value = result == null ? default(T) : NewtonsoftJsonSerializer.Instance.Deserialize<T>(result);
            return Task.FromResult<T>(value);
        }

        public Task StoreAsync<T>(string key, T value)
        {
            var jsonData = JsonConvert.SerializeObject(value);
            GoogleOauthTokenService.OauthToken = jsonData;
            return Task.Delay(0);
        }
    }
}