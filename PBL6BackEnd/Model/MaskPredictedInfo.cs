using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Model
{
    public class MaskPredictedInfo : BaseModel
    {
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string Base64String { get; set; }

        public DateTime PredictedTime { get; set; }
    }
}
