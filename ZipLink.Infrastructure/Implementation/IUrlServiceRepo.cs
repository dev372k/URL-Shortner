using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipLink.Infrastructure.Implementation
{
    public interface IUrlServiceRepo
    {
        string CreateURL(string url);
        Task<string?> GetURL(string url);
    }
}
