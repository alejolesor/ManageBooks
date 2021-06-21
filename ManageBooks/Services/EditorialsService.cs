using ManageBooks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBooks.Services
{
    public class EditorialsService : IEditorialsService
    {
        private restClient _restClient;
        public List<Editorials> GetEditorials()
        {
            try
            {
                _restClient = new restClient();
                var response = _restClient.GetEditorials();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Se presento un Error");
                    return null;
                }
                var json = response.Content.ReadAsStringAsync();
                List<Editorials> editorials = null;
                editorials = JsonConvert.DeserializeObject<List<Editorials>>(json.Result);

                return editorials;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> CreateEditorials(Editorials editorials)
        {
            try
            {
                _restClient = new restClient();
                var response = _restClient.CreateEditorial(editorials);
                var json = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Se presento un Error al crear editorial");
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
