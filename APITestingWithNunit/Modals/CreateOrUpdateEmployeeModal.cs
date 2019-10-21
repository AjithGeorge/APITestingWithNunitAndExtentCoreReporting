using System;
using System.Collections.Generic;
using System.Text;

namespace APITestingWithNunit.DTOs
{
    public class CreateOrUpdateEmployeeModal
    {
        public string id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }

    }
}
