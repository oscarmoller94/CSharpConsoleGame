using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Game
{
    /// <summary>
    /// Ett interface med det som behövs för att strida
    /// </summary>
    public interface IFightable
    {
        double Health { get; set; }
        double MaxDmg { get; set; }
        double MaxBlock { get; set; }
        void Attack(out int attackValue, out string description);
        void Defence(out int defenceValue);
    }
}
