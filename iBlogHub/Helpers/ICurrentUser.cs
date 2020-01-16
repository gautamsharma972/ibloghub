using iBlogHub.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Helpers
{
    public interface ICurrentUser
    {
        public AppUsers User { get; }
    }
}
