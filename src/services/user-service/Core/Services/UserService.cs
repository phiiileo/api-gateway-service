using System;
using System.Collections.Generic;
using user_service.Core.Dtos;
using RestSharp;
using user_service.Core.Interfaces;
using Newtonsoft.Json;

namespace user_service.Core.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        private IRestResponse HandleOpenRequest(Method method, string url, object payload)
        {
            var restClient = new RestClient(url);
            var request = new RestRequest(method);
            if(payload != null) { request.AddJsonBody(payload); }
            return restClient.Execute(request);

        }

        public List<User> getAllUsers()
        {
            //throw new NotImplementedException();
            var httpResponse = HandleOpenRequest(Method.GET, Environment.GetEnvironmentVariable("USERS.REST.URL"), null);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<User>>(httpResponse.Content);
            }
            throw new Exception($"Received a status code of {httpResponse.StatusCode} with a content of {httpResponse.Content}");
        }

        public User getUserbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
