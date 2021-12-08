using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Model
{
    public class MaskPredictedInfo : BaseModel
    {
        public string Base64String { get; set; }

        public DateTime PredictedTime { get; set; }
    }
}
