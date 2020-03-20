using System;
using System.Collections.Generic;
using System.Text;
using Test_IndeedIdWallet.Core.Models;

namespace Test_IndeedIdWallet.Core.Services
{
    public class OperationResultBuilder<T>
    {
        public static OperationResult<T> BuildSuccess(T item)
        {
            return new OperationResult<T>()
            {
                IsSuccess = true,
                Result = item,
                Messages = new string[0]
            };
        }

        public static OperationResult<T> BuildSuccess(T item, params string[] messages)
        {
            var result = BuildSuccess(item);
            result.Messages = messages;
            return result;
        }

        public static OperationResult<T> BuildError(T item)
        {
            return new OperationResult<T>()
            {
                IsSuccess = false,
                Result = item
            };
        }

        public static OperationResult<T> BuildError(T item, params string[] messages)
        {
            var result = BuildError(item);
            result.Messages = messages;
            return result;
        }
    }
}
