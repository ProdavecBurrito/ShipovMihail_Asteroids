using UnityEngine.UI;
using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class DoNothing : ICommand<ScoreUI>
    {
        public bool IsSucceed { get; private set; }

        public bool Execute(ScoreUI text)
        {
            Debug.Log("Q");
            IsSucceed = true;
            return IsSucceed;
        }

        public void RevertAction(ScoreUI item)
        {
            
        }
    }
}

