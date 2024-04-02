using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipLink.Core.Entities
{
    public class Url : Base
    {
        public Url()
        {
            ExpiryDateTime = CreatedOn.AddDays(7);
        }
        public string LongURL { get; set; } = string.Empty;
        public string ShortURL { get; set; } = string.Empty;
        public DateTime ExpiryDateTime { get; set; }
        public long Numberofclicks { get; set; }

    }
}
