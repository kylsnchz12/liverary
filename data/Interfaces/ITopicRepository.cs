using System;
using System.Linq;

namespace liverary.data.Interfaces
{
    public interface ITopicRepository
    {
        IQueryable<Topic> GetTopics();

        Topic GetTopicById(int id);

        void AddTopic(Topic topic);

        void UpdateTopic(Topic topic);

        void DeleteTopic(int id);
    }
}
