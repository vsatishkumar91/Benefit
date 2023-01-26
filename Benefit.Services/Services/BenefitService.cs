using Benefit.Services.Interfaces;
using Benefits.Models;

namespace Benefit.Services.Services
{
    public class BenefitService : IBenefitService
    {
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
            throw new NotImplementedException();
        }

        public void DeleteBenefitById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BenefitModel> GetAllBenefits()
        {
            return list;
        }

        public BenefitModel GetBenefitById(int id)
        {
            throw new NotImplementedException();
        }

        public BenefitModel GetBenefitByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateBenefit(BenefitModel model)
        {
            throw new NotImplementedException();
        }
    }
}
