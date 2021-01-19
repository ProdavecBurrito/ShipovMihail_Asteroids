using UnityEngine;

namespace Shipov_Asteroids
{
    internal class Timer
    {
        public float CurrentTime { get; private set; }
        public float EndTime { get; set; }
        public bool IsOn;

        public void Init(float time)
        {
            EndTime = time;
            IsOn = true;
        }

        public void Reset()
        {
            CurrentTime = 0.0f;
            IsOn = false;
        }

        public void CountTime()
        {
            if (IsOn)
            {
                if (CurrentTime < EndTime)
                {
                    CurrentTime += Time.deltaTime;
                }
                else
                {
                    Reset();
                }
            }
        }
    }
}
