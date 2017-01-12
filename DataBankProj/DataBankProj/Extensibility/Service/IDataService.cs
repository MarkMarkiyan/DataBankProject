using System;
using System.Collections.Generic;

namespace DataBankProj.Extensibility
{
    public interface IDataService
    {
        List<string> GetListOfTypes();

        void InsertData(object obj, string type);

        IEnumerable<object> GetDataByType(string type);

        object GetByIdAndType(int id, string type);

        Type GetTypeByName(string typeName);
    }
}