using System;
using System.Threading.Tasks;
namespace BTTP
{
    public interface IRestService
    {
        Task<AllData> RefreshDataAsync();
    }
}