using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface ICore
    {
        Task<bool> Write(string value);
    }
}
