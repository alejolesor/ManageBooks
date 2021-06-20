using ManageBooks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBooks.Services
{
    public class BooksApiClient : IBooksApiClient
    {
        private restClient _restClient;

        public List<Books> GetBooksAsync()
        {
            try
            {
                _restClient = new restClient();
               var response = _restClient.GetBooks();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Se presento un Error");
                    return null;
                }
                var json =   response.Content.ReadAsStringAsync();
                List<Books> books = null;
                books = JsonConvert.DeserializeObject<List<Books>>(json.Result);

                return books;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateBooksAsync(Books book)
        {
            try
            {
                _restClient = new restClient();
                var response = _restClient.CreateBook(book);
                var json = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Se presento un Error");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }


    }
}
