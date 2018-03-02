using System;
using System.Collections.Generic;

namespace Entities
{
    public class Employee : Info
    {
        public IList<Info> Dependents { get; set; }
    }
}
