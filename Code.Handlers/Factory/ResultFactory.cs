using Code.Handlers.RequestModel;
using Code.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Handlers.Factory
{
    public interface IResultFactory
    {
        ResultEntity CreateResultEntity(InfoRequest request, string response);
    }

    // Factory Pattern
    public class ResultFactory : IResultFactory
    {
        public ResultEntity CreateResultEntity(InfoRequest request, string response)
        {
            ResultEntity result = new ResultEntity()
            {
                Request = request.Input,
                Response = response,
                User = request.User,
                RequestDate = request.RequestDate,
                ResponseDate = DateTime.UtcNow,
            };

            return result;
        }
    }
}
