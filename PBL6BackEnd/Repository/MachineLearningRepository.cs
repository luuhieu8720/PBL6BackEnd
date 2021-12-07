using PBL6BackEnd.DTO.MachineLearningDTO;
using PBL6BackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public class MachineLearningRepository : IMachineLearningRepository
    {
        public async Task<ResultResponse> Get(RequestForm requestForm)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://7374-35-201-237-215.ngrok.io/");
            //HTTP GET
            var responseTask = client.PostAsJsonAsync("predict/image", requestForm);
            responseTask.Wait();

            var result = responseTask.Result;

            if (!result.IsSuccessStatusCode)
            {
                throw new BadRequestException("Unable to get results. Please send another request");
            }

            var readTask = result.Content.ReadAsAsync<ResultResponse>();
            return await readTask;
        }
    }
}
