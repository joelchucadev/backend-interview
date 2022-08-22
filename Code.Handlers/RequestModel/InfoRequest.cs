using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Handlers.RequestModel
{
    // InfoRequest is a simple DTO has the neccesary information comming from client.
    // Part of Command Handler pattern
    public class InfoRequest : IRequest<string>
    {
        public string Input { get; set; }
        public string User { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
