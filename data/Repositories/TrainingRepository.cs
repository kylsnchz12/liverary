using liverary.data.Interfaces;
using liverary.data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liverary.data.Repositories
{
    public class TrainingRepository : BaseRepository, ITrainingRepository
    {

        public TrainingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        public IQueryable<Training> GetTrainings()
        {
            return this.GetDbSet<Training>();
        }



        public void AddUser(Training training)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Training>();

            // Add the new training record
            dbSet.Add(training);

            // Save the changes
            this.SaveChanges();
        }

        public void deleteTraining(string trainingId)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Training>();

            // Find the existing training record
            var existingTraining = dbSet.Find(trainingId);

            if (existingTraining != null)
            {
                // Remove the training record
                dbSet.Remove(existingTraining);

                // Save the changes
                this.SaveChanges();
            }
            else
            {
                // Handle the case where the training record was not found
                Console.WriteLine($"Training record with ID {trainingId} not found.");
            }
        }


        public void updateTraining(Training training, string trainingId)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Training>();

            // Find the existing training record
            var existingTraining = dbSet.Find(trainingId);

            if (existingTraining != null)
            {
                // Update the fields of the existing training record
                existingTraining.trainingId = training.trainingId;
                existingTraining.trainingName = training.trainingName;
                existingTraining.Description = training.Description;
                existingTraining.CreatedTime = training.CreatedTime;
                existingTraining.UpdatedTime = training.UpdatedTime;


                // Save the changes
                this.SaveChanges();
                UnitOfWork.SaveChanges();
            }
            p
            else
            {
                // Handle the case where the training record was not found
                Console.WriteLine($"Training record with ID {trainingId} not found.");
            }
        }


}
}