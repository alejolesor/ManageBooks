using ManageBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ManageBooks.Services
{
    public class restClient
    {
        string urlApi = "https://localhost:44330/api/Books";
        public HttpResponseMessage GetBooks()
        {
            var endpoint = urlApi;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage CreateBook(Books value)
        {
            var endpoint = urlApi;
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, value).Result;
            client.Dispose();
            return response;
        }
    }
}
