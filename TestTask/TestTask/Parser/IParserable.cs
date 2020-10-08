using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestTask
{
    interface IParserable
    {
        void Parse(XElement ParsedData);
    }
}
