using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    public class CompareByName : IComparer<Player>
    {
        private bool order;
        public CompareByName(bool order = true)
        {
            this.order = order;
        }

        public int Compare(Player player1, Player player2)
        {
            int result = string.Compare(player1.Name, player2.Name);
            return order ? result : - result;
        }
    }
}
