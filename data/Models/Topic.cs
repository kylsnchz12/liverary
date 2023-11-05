using System;

using System.Collections.Generic;


namespace liverary.data.Models
{
    public partial class Topic
    {

        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public int TrainingId { get; set; } // Foreign key for Training

        // Navigation property for Training
        public virtual Training Training { get; set; }
    }
}
