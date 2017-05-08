using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Phone
{
    public class Phone
    {
        public string DDD { get; private set; }
        public string Number { get; private set; }

        protected Phone()
        {

        }

        public static Phone Create(string DDD, string number)
        {
            var phone = new Phone();
            phone.DDD = DDD;
            phone.Number = number;

            return phone;
        }
    }
}
