using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmishim.Lottery
{
    [System.Serializable]
    public class Ticket
    {
        [SerializeField]
        [Range(0f, 100f)]
        float _Probability;
        [SerializeField]
        int _Rarity;
        [SerializeField]
        string _Name;
        [SerializeField]
        GameObject _Prefab;

        int _HitRangeMin;
        int _HitRangeMax;

        public float Probability
        {
            get
            {
                return _Probability;
            }
            private set
            {
                _Probability = value;
            }
        }

        public int Rarity
        {
            get
            {
                return _Rarity;
            }
            private set
            {
                _Rarity = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            private set
            {
                _Name = value;
            }
        }

        public GameObject Prefab
        {
            get
            {
                return _Prefab;
            }
            private set
            {
                _Prefab = value;
            }
        }

        public int HitRangeMin
        {
            get
            {
                return _HitRangeMin;
            }
            set
            {
                _HitRangeMin = value;
            }
        }

        public int HitRangeMax
        {
            get
            {
                return _HitRangeMax;
            }
            set
            {
                _HitRangeMax = value;
            }
        }
    }
}
