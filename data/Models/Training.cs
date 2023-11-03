using System;

using System.Collections.Generic;

namespace liverary.data.Models
{
    public partial class Training
    {
        public int trainingId { get; set; }

        public string trainingName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

}
}
