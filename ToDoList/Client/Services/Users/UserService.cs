﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Requests;

namespace ToDoList.Client.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Login(UserLoginRequest user)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/signin", user);
            return result;
        }

        public async Task<HttpResponseMessage> Register(User user)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/signup", user);
            return result;
        }

        public async Task<HttpResponseMessage> Update(User user)
        {
            var result = await _httpClient.PutAsJsonAsync("user", user);
            return result;
        }

        public async Task<HttpResponseMessage> Delete(Guid userId)
        {
            var result = await _httpClient.DeleteAsync($"user/{userId}");
            return result;
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<User>>($"user");
            return result;
        }
    }
}
