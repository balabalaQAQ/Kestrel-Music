using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel.Identity.Helpers
{
    public interface IGenericControllerLocalizer<T> : IStringLocalizer<T>
    {
    }
}
