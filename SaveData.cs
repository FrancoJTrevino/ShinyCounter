using System;
using System.Collections.Generic;
using System.Text;

namespace ShinyCounter
{
    internal class SaveData
    {
        public string Pokemon { get; set; }
        public int Counter { get; set; }
        public DateTime? StarterDate { get; set; }
        public SaveData(string pokemon, int counter = 0, DateTime? starterDate = null)
        {
            Pokemon = pokemon;
            Counter = counter;
            StarterDate = starterDate;
        }
    }
}
