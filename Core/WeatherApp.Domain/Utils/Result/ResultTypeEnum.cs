using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Domain.Utils.Result
{
    public enum ResultType : short
    {
        InternalError = 0,
        Ok = 1,
        NotFound = 2,
        Forbidden = 3,
        Conflicted = 4,
        Validation = 5,
        Unauthorized = 6,
        ServiceUnavailable = 7,
    }
}
