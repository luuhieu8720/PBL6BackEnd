using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.DTO.MaskPredictDTO
{
    public class MaskPredictForm
    {
        public string Base64String { get; set; }

        public DateTime PredictedTime { get; set; }
    }
}
