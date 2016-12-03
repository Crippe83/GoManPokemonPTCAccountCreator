using System;

namespace GoManPTCAccountCreator.Controller
{
    public partial class Account
    {
        private class MethodResult
        {
            public Exception Error { get; set; }
            public bool Success { get; set; }
        }

        private class MethodResult<T> : MethodResult
        {
            public T Value { get; set; }

        }
    }
}
