using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmishim.Lottery
{
    public class TicketContainer : ScriptableObject
    {
        [Tooltip("小数点以下の有効桁数")]
        [Range(0, 4)]
        public uint SignificantDigits;
        public Ticket[] Tickets;
    }
}
