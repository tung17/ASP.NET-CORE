using System;
using System.Collections.Generic;
using System.Text;

namespace Support.Interfaces
{
    public interface IResponse<T>
    {
        bool Status { get; set; }
        int Code { get; set; }
        T Data { get; set; }
        string msg { get; set; }
    }
}
