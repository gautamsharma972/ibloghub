using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class ResultsModel
    {
        public Exception Exception { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public Guid ModelId { get; set; }

        public string Slug { get; set; }
    }
}
