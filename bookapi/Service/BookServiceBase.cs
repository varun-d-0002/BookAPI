using bookapi.Data;
using bookapi.Model;
using Dapper;

namespace bookapi.Service
{
    public class BookServiceBase
    {
        private string id;
        private object list_data;
        private object context;

        public object GetList_data()
        {
            return list_data;
        }
    }
}