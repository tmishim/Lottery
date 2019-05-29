using UnityEngine;

namespace tmishim.Lottery
{
    /// <summary>
    /// UnityEngine.Randomを複数インスタンス化するためのラッパー.
    /// </summary>
    public class MultiRandom
    {
        Random.State state;
        // 退避用
        Random.State stateBackup;

        public MultiRandom() : this((int) System.DateTime.Now.Ticks)
        { }

        public MultiRandom(int seed)
        {
            setSeed(seed);
        }

        public void setSeed(int seed)
        {
            Random.State prevState = Random.state;
            Random.InitState(seed);
            state = Random.state;
            Random.state = prevState;
        }

        /// <summary>
        /// Return a random float number between min [inclusive] and max [exclusive]
        /// </summary>
        /// <param name="min">minimum value [inclusive]</param>
        /// <param name="max">maximum value [exclusive]</param>
        /// <returns></returns>
        public int Range(int min, int max)
        {
            BeforeGen();
            int r = Random.Range(min, max);
            AfterGen();
            return r;
        }

        /// <summary>
        /// Return a random float number between min [inclusive] and max [inclusive]
        /// </summary>
        /// <param name="min">minimum value [inclusive]</param>
        /// <param name="max">maximum value [inclusive]</param>
        /// <returns></returns>
        public float Range(float min, float max)
        {
            BeforeGen();
            float r = Random.Range(min, max);
            AfterGen();
            return r;
        }

        #region Backup and Restore Random.state
        void BeforeGen()
        {
            stateBackup = Random.state;
            Random.state = state;
        }

        void AfterGen()
        {
            state = Random.state;
            Random.state = stateBackup;
        }
        #endregion
    }
}
