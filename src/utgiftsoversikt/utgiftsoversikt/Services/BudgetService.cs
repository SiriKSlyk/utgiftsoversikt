
using System.Diagnostics.Eventing.Reader;

using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IBudgetService
    {
        void Create(Budget budget);
        List<Budget> GetAll(string userId);
        Budget GetById(string id);
        public void Delete(Budget budget);
        void Update(Budget budget);

    }
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            
            _budgetRepo = budgetRepo;
        }

        public void Create(Budget budget)
        {
            _budgetRepo.Create(budget);
        }

        public void Delete(Budget budget)
        {
            _budgetRepo.Delete(budget);
        }

        public List<Budget> GetAll(string userId)
        {
            return _budgetRepo.GetAll(userId);
        }

        public Budget GetById(string id)
        {
            return _budgetRepo.GetById(id);
        }

        public void Update(Budget budget)
        {
            _budgetRepo.Update(budget);
        }
    }
}