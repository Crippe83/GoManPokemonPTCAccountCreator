﻿using System;

namespace GoManPTCAccountCreator.Controller
{
    public partial class Account
    {
        private class MethodResult
        {
            public Exception Error { get; set; }
            public bool Success { get; set; }
            public string Value { get; set; }
        }
    }
}
