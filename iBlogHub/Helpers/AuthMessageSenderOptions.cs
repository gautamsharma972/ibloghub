﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Helpers
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; } = "@iBlogHub"; // get from json secret manager
        public string SendGridKey { get; set; } = "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";
    }
}
