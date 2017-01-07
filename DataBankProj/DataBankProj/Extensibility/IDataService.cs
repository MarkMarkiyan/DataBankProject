using System;
using System.Collections.Generic;

namespace DataBankProj.Extensibility
{
    public interface IDataService
    {
        void InsertData(object obj, Type type);

        IEnumerable<object> GetDataByType(Type type);
    }
}