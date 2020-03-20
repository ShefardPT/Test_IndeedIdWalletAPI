using System;
using System.Collections.Generic;
using System.Text;

namespace Test_IndeedIdWallet.Core.Models
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string[] Messages { get; set; }
        public T Result { get; set; }
    }
}
