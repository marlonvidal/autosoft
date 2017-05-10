using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Items
{
    public class ItemDiscrimination : ValueObject<int>
    {
        protected ItemDiscrimination()
        {

        }

        public string Description { get; private set; }
        public MeasurementTypes MeasurementType { get; private set; }
        public decimal Value { get; private set; }
    }
}
