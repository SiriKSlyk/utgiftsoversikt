<<<<<<< HEAD
﻿
using System.Diagnostics.Eventing.Reader;

using utgiftsoversikt.Models;
=======
﻿using utgiftsoversikt.Models;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IBudgetService
    {
<<<<<<< HEAD
        void Create(Budget budget);
        List<Budget> GetAll(string userId);
        Budget GetById(string id);
        public void Delete(Budget budget);
        void Update(Budget budget);
=======
        bool Create(Budget budget);
        List<Budget> GetAll(string userId);
        Budget GetById(string id);
        bool Delete(Budget budget);
        bool Update(Budget budget);

>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

    }
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            
            _budgetRepo = budgetRepo;
        }

<<<<<<< HEAD
        public void Create(Budget budget)
        {
            budget.Id = Guid.NewGuid().ToString();
            _budgetRepo.Create(budget);
        }

        public void Delete(Budget budget)
        {
            _budgetRepo.Delete(budget);
=======
        public bool Create(Budget budget)
        {
            budget.Id = Guid.NewGuid().ToString();
            _budgetRepo.Create(budget);
            return _budgetRepo.Write().Result;
        }

        public bool Delete(Budget budget)
        {
            _budgetRepo.Delete(budget);
            return _budgetRepo.Write().Result;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }

        public List<Budget> GetAll(string userId)
        {
            return _budgetRepo.GetAll(userId);
        }

        public Budget GetById(string id)
        {
            return _budgetRepo.GetById(id);
        }

<<<<<<< HEAD
        public void Update(Budget budget)
        {
            _budgetRepo.Update(budget);
        }
=======
        public bool Update(Budget budget)
        {
            _budgetRepo.RemoveTrace(budget);
            _budgetRepo.Update(budget);
            return _budgetRepo.Write().Result;
        }

>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
    }
}