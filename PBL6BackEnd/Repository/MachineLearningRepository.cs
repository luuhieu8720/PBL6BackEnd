using Microsoft.EntityFrameworkCore;
using PBL6BackEnd.DTO.MachineLearningDTO;
using PBL6BackEnd.DTO.MaskPredictDTO;
using PBL6BackEnd.Exceptions;
using PBL6BackEnd.Model;
using PBL6BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public class MachineLearningRepository : IMachineLearningRepository
    {
        private readonly DataContext dataContext;

        public MachineLearningRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ResultResponse> Get(RequestForm requestForm)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://c339-34-70-231-224.ngrok.io/");
            
            var responseTask = client.PostAsJsonAsync("predict/image", requestForm);
            responseTask.Wait();

            var result = responseTask.Result;

            if (!result.IsSuccessStatusCode)
            {
                throw new BadRequestException("Unable to get results. Please send another request");
            }

            var readTask = result.Content.ReadAsAsync<ResultResponse>();

            if (String.Compare(readTask.Result.Result, "without_mask") == 0)
            {
                var maskPredicted = new MaskPredictForm()
                {
                    Base64String = requestForm.Base64String,
                    PredictedTime = DateTime.Now
                };

                await Create(maskPredicted);
            }

            return await readTask;
        }

        public async Task Create(MaskPredictForm maskPredictForm)
        {
            await dataContext.AddAsync(maskPredictForm.ConvertTo<MaskPredictedInfo>());
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<MaskPredictItem>> Get()
        {
            return await dataContext.MaskPredictedInfos.Select(x => x.ConvertTo<MaskPredictItem>())
                .ToListAsync();
        }
    }
}
