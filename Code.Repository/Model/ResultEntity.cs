using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Repository.Model
{
    // Repository Pattern
    public class ResultEntity
    {
        [Key]
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string User { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
