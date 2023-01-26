using Benefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefit.DataAccessLayer
{
    public interface IBenefitRepository
    {
        int Create(BenefitModel BenefitModel);

        List<BenefitModel> GetAll();

        int Update(BenefitModel BenefitModel);

        int Delete(int id);

        BenefitModel GetBenefit(int id);


    }
}
