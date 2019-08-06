using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Response<T>: IResponse<T>
    {
        public bool Status { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
        public string msg { get; set; }
    }
}
