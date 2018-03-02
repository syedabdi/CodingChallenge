using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Commands
{
    public class AddEmployee
    {
        public Info Employee { get; set; }
        public IEnumerable<Info> Dependents { get; set; }
    }
}
