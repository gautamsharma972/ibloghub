using System;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public ErrorType ErrorType { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
