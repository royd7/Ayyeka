using System.Collections.Generic;

namespace CensusApp.Models
{
    public interface IDataManager
    {
        void DeleteById(int id);
        List<object> ReadDataByFilter(List<Filter> filter);
        bool Update(int id, string propertyName, string propertyValue);
    }
}