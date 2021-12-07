using PBL6BackEnd.DTO.MachineLearningDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Repository
{
    public interface IMachineLearningRepository
    {
        Task<ResultResponse> Get(RequestForm requestForm);
    }
}
