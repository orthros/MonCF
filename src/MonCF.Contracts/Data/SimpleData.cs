using System;
using System.Runtime.Serialization;

namespace MonCF.Contracts.Data
{
    [DataContract]
    public class SimpleData
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumberOfOccurances { get; set; }

        public SimpleData() { }

        public SimpleData(Guid uiD, string name, int occurances)
            : base()
        {
            this.Id = uiD;
            this.Name = name;
            this.NumberOfOccurances = occurances;
        }

        public override bool Equals(object obj)
        {
            var that = obj as SimpleData;
            if(that != null)
            {
                return this.Id == that.Id &&
                       this.Name == that.Name &&
                       this.NumberOfOccurances == that.NumberOfOccurances;
            }

            return false;
        }

    }
}
