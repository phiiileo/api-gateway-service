﻿using System;
using System.Collections.Generic;
using user_service.Core.Dtos;
using RestSharp;
using user_service.Core.Interfaces;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace user_service.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        private IRestResponse HandleOpenRequest(Method method, string url, User payload)
        {
            var restClient = new RestClient(url);
            var request = new RestRequest(method);
            if(payload != null) { request.AddJsonBody(payload); }
            return restClient.Execute(request);

        }

        public List<User> getAllUsers()
        {
            try {
                var httpResponse = HandleOpenRequest(Method.GET, Environment.GetEnvironmentVariable("USERS.REST.URL"), null);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<User>>(httpResponse.Content);
                }
                throw new Exception($"Received a status code of {httpResponse.StatusCode} with a content of {httpResponse.Content}");
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.Message);
                return null;
            }
        }

        public User getUserbyId(int id)
        {
            try {
                var httpResponse = HandleOpenRequest(Method.GET, Environment.GetEnvironmentVariable("USERS.REST.URL")+$"/{id}", null);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<User>(httpResponse.Content);

                }
                throw new Exception(httpResponse.Content);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return null;
            }
        }

        public User createNewUser(User body)
        {
            var httpResponse = HandleOpenRequest(Method.POST, Environment.GetEnvironmentVariable("USERS.REST.URL"), body);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<User>(httpResponse.Content);
            }
            return null;
        }

        public string checkDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
