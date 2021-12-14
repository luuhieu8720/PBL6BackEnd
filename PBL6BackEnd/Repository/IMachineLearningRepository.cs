using PBL6BackEnd.DTO.MachineLearningDTO;
using PBL6BackEnd.DTO.MaskPredictDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public interface IMachineLearningRepository
    {
        Task<ResultResponse> Get(RequestForm requestForm);

        Task Create(MaskPredictForm maskPredictForm);

        Task<List<MaskPredictItem>> Get();

        Task Delete();
    }
}
