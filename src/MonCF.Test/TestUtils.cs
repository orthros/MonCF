using MonCF.Contracts.Data;
using Orth.Core.Utils;
using System;
using System.Collections.Generic;

namespace MonCF.Tests
{
    public static class TestUtils
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static SimpleData GetRandomSimpleData(int nameMax = 10, int valueMax = 50)
        {
            SimpleData sd = new SimpleData(Guid.NewGuid(), Utilities.RandomString(nameMax), random.Next(valueMax));

            return sd;
        }

        public static ComplexData GetRandomComplexData(int nameSize = 10, int maxSubItems = 50)
        {
            ComplexData cd = new ComplexData();
            cd.Id = Guid.NewGuid();
            cd.Name = Utilities.RandomString(nameSize);
            var totalSubItems = random.Next(maxSubItems);
            cd.SubItems = new List<SubitemData>(totalSubItems);
            for(int i =0; i < totalSubItems; i++)
            {
                cd.SubItems.Add(GetRandomSubItemData(nameSize));
            }
            cd.DataType = GetRandomEnumValue();

            return cd;
        }

        public static SubitemData GetRandomSubItemData(int nameSize = 50)
        {
            SubitemData sid = new SubitemData();
            sid.ItemName = Utilities.RandomString(nameSize);
            sid.ItemQuantity = random.NextDouble();

            return sid;
        }

        public static ComplexDataTypeEnum GetRandomEnumValue()
        {
            var values = Enum.GetValues(typeof(ComplexDataTypeEnum));
            return (ComplexDataTypeEnum)values.GetValue(random.Next(values.Length));
        }
    }
}
