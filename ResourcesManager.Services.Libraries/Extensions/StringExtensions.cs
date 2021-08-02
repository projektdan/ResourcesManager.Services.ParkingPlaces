using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.Libraries.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}
