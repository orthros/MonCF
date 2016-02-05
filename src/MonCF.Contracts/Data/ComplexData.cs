using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MonCF.Contracts.Data
{
    [DataContract]
    public class ComplexData
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<SubitemData> SubItems { get; set; }

        [DataMember]
        public ComplexDataTypeEnum DataType { get; set; }

        public ComplexData() { }

        public ComplexData(Guid uid, string name, List<SubitemData> items, ComplexDataTypeEnum dataType)
            : base()
        {
            this.Id = uid;
            this.Name = name;
            this.SubItems = items;
            this.DataType = dataType;
        }

        public override bool Equals(object obj)
        {
            var that = obj as ComplexData;
            if (that != null)
            {
                return this.Id == that.Id &&
                       this.Name == that.Name &&
                       this.DataType == that.DataType &&
                       this.SubItems.SequenceEqual(that.SubItems);
            }

            return false;
        }
    }
}
