using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using tmishim.Lottery;
using UnityEngine;

public class LotteryTest
{
    [SerializeField]
    TicketContainer ticketContainer;

    [Test]
    public void ProbabilityTest()
    {
        var ticketsContainer = Resources.Load<TicketContainer>("Tickets");
        Lottery lottery = new Lottery(ticketsContainer);

        int drawCount = 1000000;
        Ticket[] tickets = lottery.Draw(drawCount);

        tickets
            .GroupBy(e => e.Name)
            .ToList()
            .ForEach(e =>
            {
                Ticket rep = e.First();
                string rare = new string('★', rep.Rarity);
                Debug.LogFormat("{0} {1} レア度:{2,-5}", e.Count(), rep.Name, rare);
            });
    }
}
