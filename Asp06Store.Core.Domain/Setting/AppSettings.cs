using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Asp.Net.Core_07.Domain.Setting
{
    public record AppSettings
    {
        public int pageSize { get; set; }
    }
}
