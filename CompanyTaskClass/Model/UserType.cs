using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTaskClass.Model
{
    public class KeyNamePair
    {
        public KeyNamePair(int key, string name)
        {
            this.Key = key;
            this.Name = name;
        }

        public int Key { set; get; }
        public string Name { set; get; }
    }

    public enum UserType : byte
    {
        Weike = 1
    }
}
