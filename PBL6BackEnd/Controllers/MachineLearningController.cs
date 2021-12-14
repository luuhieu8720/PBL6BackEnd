using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBL6BackEnd.DTO.MachineLearningDTO;
using PBL6BackEnd.DTO.MaskPredictDTO;
using PBL6BackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Controllers
{
    [Route("api/ml")]
    public class MachineLearningController : Controller
    {
        private readonly IMachineLearningRepository machineLearningRepository;

        public MachineLearningController(IMachineLearningRepository machineLearningRepository)
        {
            this.machineLearningRepository = machineLearningRepository;
        }

        [HttpPost("predict")]
        public async Task<ResultResponse> Get([FromBody]RequestForm requestForm) => await machineLearningRepository.Get(requestForm);

        [HttpGet("predict")]
        [Authorize]
        public async Task<List<MaskPredictItem>> Get() => await machineLearningRepository.Get();

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task Delete() => await machineLearningRepository.Delete();
    }
}
