using System.Collections.Generic;

namespace YVN.Web.Services
{
    public interface IYearsService
    {
        IEnumerable<int> GetLastYears(int count);
    }
}
