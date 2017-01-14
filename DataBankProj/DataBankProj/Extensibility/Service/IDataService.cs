using System;
using System.Collections.Generic;

namespace DataBankProj.Extensibility.Service
{
    public interface IDataService
    {
        List<string> GetListOfTypes();

        void DeleteDataByTypeAndId(string typeName, int id);

        void InsertData(object obj, string type);

        IEnumerable<object> GetDataByType(string type);

        object GetByIdAndType(int id, string type);

        Type GetTypeByName(string typeName);
    }
}