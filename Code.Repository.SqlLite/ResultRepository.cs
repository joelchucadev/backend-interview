using Code.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Repository.SqlLite
{
    // Repository Pattern
    public class ResultRepository : IResultRepository
    {
        private readonly MyContext _myContext;

        public ResultRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public void SaveResult(ResultEntity entity)
        {
            _myContext.ResultEntity.Add(entity);
            _myContext.SaveChanges();
        }
    }
}
