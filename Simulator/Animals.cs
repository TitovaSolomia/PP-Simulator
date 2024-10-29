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
        init
        {
            var checked_descrip = value.Trim();

            if (checked_descrip.Length > 15)
            {
                checked_descrip = checked_descrip.Substring(0, 15).TrimEnd();
            }

            if (checked_descrip.Length < 3)
            {
                checked_descrip = checked_descrip.PadRight(3, '#');
            }

            if (char.IsLower(checked_descrip[0]))
            {
                checked_descrip = char.ToUpper(checked_descrip[0]) + checked_descrip.Substring(1);
            }

            description = checked_descrip;
        }
    }
    public uint Size { get; set; } = 3;                
    public string Info => $"{Description} <{Size}>";
    
}
