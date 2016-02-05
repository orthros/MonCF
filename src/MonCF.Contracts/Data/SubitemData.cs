using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MonCF.Contracts.Data
{
    /// <summary>
    /// Class to Represent a small data type that might be a member of a 
    /// more complex data type
    /// </summary>
    [DataContract]
    public class SubitemData
    {
        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public double ItemQuantity { get; set; }

        public SubitemData() { }

        public SubitemData(string name, double quantity) 
            : base()
        {
            this.ItemName = name;
            this.ItemQuantity = quantity;
        }

        public override bool Equals(object obj)
        {
            var that = obj as SubitemData;
            if(that != null)
            {
                return this.ItemName == that.ItemName &&
                       this.ItemQuantity == that.ItemQuantity;
            }

            return false;
        }
    }
}
