using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benefits.Models;

namespace Benefit.Services.Interfaces
{
    public interface IBenefitService
    {
        List<BenefitModel> GetAllBenefits();
        BenefitModel GetBenefitById(int id);

        BenefitModel GetBenefitByName(string name);

        int CreateBenefit(BenefitModel model);

        void UpdateBenefit(BenefitModel model);

        void DeleteBenefitById(int id);
    }
}
