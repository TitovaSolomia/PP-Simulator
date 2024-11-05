using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

 public class Animals
{
    private string description = "Unknown";

    public string Description
    {
        get => description;
        init => description=Validator.Shortener(value, 3, 10, '#');
    }
    public uint Size { get; set; } = 3;

    public override string ToString()
    {
        var className = this.GetType().Name;
        return $"{className.ToUpper()}: {this.Info}";
    }
    public virtual string Info 
    { 
        get { return $"{Description} <{Size}>"; }
    }
    
}
