using UnityEngine.UI;
using UnityEngine;

namespace Shipov_Asteroids
{
    public class ShowScore : ICommand<ScoreUI>
    {
        public bool IsSucceed { get; private set; }
        public bool IsOpen { get; private set; }

        public bool Execute(ScoreUI text)
        {
            if (IsOpen)
            {
                text.HideScore();
                IsOpen = false;
                Debug.Log("Is");
                return IsSucceed = true;
            }
            Debug.Log("!Is");
            text.ShowScore();
            IsOpen = true;
            return IsSucceed = true;
        }

        public void RevertAction(ScoreUI text)
        {
            Execute(text);
        }
    }
}
