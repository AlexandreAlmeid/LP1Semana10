using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayerManagerMVC
{
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; set; }
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public int CompareTo(Player other)
        {
            if (other == null) return 1; 
            return other.Score - this.Score;
        }
    }
    class CompareByName : IComparer<Player>
    {
        public bool Mode { get; set; } //false = Descend, true = Ascend
        public CompareByName(bool mode)
        {
            Mode = mode;
        }
        public int Compare(Player x, Player y)
        {
            if (Mode)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return - x.Name.CompareTo(y.Name);
            }
        }
    }

}