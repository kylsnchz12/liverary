using liverary.data.Models;
using System;
using System.Linq;

namespace liverary.data.Interfaces
{
	public interface ITrainingRepository
	{
		IQueryable<training> GetTrainings();

        void AddUser(Training training);

        void deleteTraining(string trainingId);

        void updateTraining(Training training, string trainingId);
    }
}


