using Benefit.DataAccessLayer;
using Benefit.Services.Interfaces;
using Benefits.Models;

namespace Benefit.Services.Services
{
    public class BenefitService : IBenefitService
    {
        public readonly IBenefitRepository _benefitRepository;

        public BenefitService(IBenefitRepository benefitRepository)
        {
            _benefitRepository = benefitRepository;
        }

        static List<BenefitModel> list = new List<BenefitModel>()
        {
            new BenefitModel() { Name = "test1", Id = 1 },
            new BenefitModel() { Name = "test2", Id = 2 },
            new BenefitModel() { Name = "test3", Id = 3 },
            new BenefitModel() { Name = "test4", Id = 4 },
            new BenefitModel() { Name = "test5", Id = 5 },
        };

        public int CreateBenefit(BenefitModel model)
        {
            return _benefitRepository.Create(model);
        }

        public void DeleteBenefitById(int id)
        {
            _benefitRepository.Delete(id);
        }

        public List<BenefitModel> GetAllBenefits()
        {
            return list;
        }

        public BenefitModel GetBenefitById(int id)
        {
            return _benefitRepository.GetBenefit(id);
        }

        public BenefitModel GetBenefitByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateBenefit(BenefitModel model)
        {
            _benefitRepository.Update(model);
        }
    }
}
