using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tmishim.Lottery
{
    public class Lottery
    {
        MultiRandom _Rng;
        Ticket[] _Tickets;
        int Bias;

        Ticket[] Tickets
        {
            get
            {
                return _Tickets;
            }
            set
            {
                _Tickets = value;
                if (_Tickets != null && _Tickets.Length > 0)
                {
                    _Tickets = _Tickets.OrderByDescending(e => e.Rarity).ToArray();
                    int x = 0;
                    float totalProb = 0.0f;

                    for (int i = 0, iEnd = _Tickets.Length; i < iEnd; i++)
                    {
                        _Tickets[i].HitRangeMin = x;
                        x += (int) (_Tickets[i].Probability * Bias);
                        _Tickets[i].HitRangeMax = x;
                        //UnityEngine.Debug.Log(_Tickets[i].HitRangeMin + "-" + _Tickets[i].HitRangeMax);

                        totalProb += _Tickets[i].Probability;
                        if (totalProb > 100.0f)
                        {
                            UnityEngine.Debug.LogError("Total probability limit (100%) exceeds");
                        }
                    }
                }
            }
        }

        public Lottery(TicketContainer tc) : this(new MultiRandom(), tc)
        { }

        public Lottery(MultiRandom rng, TicketContainer tc)
        {
            _Rng = rng;
            Bias = IntPow(10, tc.SignificantDigits);
            Tickets = tc.Tickets;
        }

        public Ticket[] Draw(int n)
        {
            if (n <= 0)
            {
                return null;
            }

            List<Ticket> result = new List<Ticket>();
            for (int i = 0; i < n; i++)
            {
                Ticket t = Draw();
                if (t != null)
                {
                    result.Add(t);
                }
            }
            return result.ToArray();
        }

        public Ticket Draw()
        {
            if (Tickets == null || Tickets.Length == 0)
            {
                return null;
            }

            int rval = _Rng.Range(0, (100 * Bias) + 1);
            for (int i = 0, iEnd = _Tickets.Length; i < iEnd; i++)
            {
                if (rval >= _Tickets[i].HitRangeMin && rval < _Tickets[i].HitRangeMax)
                {
                    return _Tickets[i];
                }
            }
            return null;
        }

        int IntPow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }
}
