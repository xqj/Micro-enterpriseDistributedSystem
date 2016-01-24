using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.BaseModel
{
    public class KeyVal<K,V>
    {
        public K Key
        {
            set;get;
        }

        public V Val
        {
            set;get;
        }
    }
}