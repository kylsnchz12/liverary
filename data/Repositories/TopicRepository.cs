using liverary.data.Interfaces;
using liverary.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liverary.data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        public IQueryable<Topic> GetTopics()
        {
            return this.GetDbSet<Topic>();
        }


        public Topic GetTopicById(int id)
        {
            var dbSet = this.GetDbSet<Topic>();
            var topic = dbSet.Find(id);

            if (topic == null)
            {
                throw new ArgumentException($"No topic found with ID {id}");
            }

            return topic;
        }



        public void AddTopic(Topic topic)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Topic>();

            // Add the new topic record
            dbSet.Add(topic);

            // Save the changes
            this.SaveChanges();
        }

        public void DeleteTopic(string topicId)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Topic>();

            // Find the existing topic record
            var existingTopic = dbSet.Find(topicId);

            if (existingTopic != null)
            {
                // Remove the topic record
                dbSet.Remove(existingTopic);

                // Save the changes
                this.SaveChanges();
            }
            else
            {
                // Handle the case where the topic record was not found
                Console.WriteLine($"Topic record with ID {topicId} not found.");
            }
        }

        public void UpdateTopic(Topic topic, string topicId)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Topic>();

            // Find the existing topic record
            var existingTopic = dbSet.Find(topicId);

            if (existingTopic != null)
            {
                // Update the fields of the existing topic record
                existingTopic.TopicId = topic.TopicId;
                existingTopic.TopicName = topic.TopicName;
                existingTopic.Description = topic.Description;
                existingTopic.CreatedTime = topic.CreatedTime;
                existingTopic.UpdatedTime = topic.UpdatedTime;
                existingTopic.TrainingId = topic.TrainingId;

                // Save the changes
                this.SaveChanges();
            }
            else
            {
                // Handle the case where the topic record was not found
                Console.WriteLine($"Topic record with ID {topicId} not found.");
            }
        }
    }
}

