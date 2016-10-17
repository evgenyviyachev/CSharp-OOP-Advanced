﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03BarracksFactory.Attributes
{
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string aliasName)
        {
            this.Name = aliasName;
        }

        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}
