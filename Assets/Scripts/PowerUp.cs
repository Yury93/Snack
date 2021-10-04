
using UnityEngine;


namespace Snake
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private Destructible destructibleSnack;
        [SerializeField] private InputPlayer inputPlayer;
        [SerializeField] private float timerPowerUp;
        [SerializeField] private bool startTimer;
        public bool startTimerFever => startTimer;
        private float newTime;
        private void Start()
        {
           newTime = timerPowerUp;
        }
        private void Update()
        {
            if(startTimer == true)
            {
                timerPowerUp -= Time.deltaTime;
                if(timerPowerUp < 0)
                {
                    AddFever(false, 3, false);
                    timerPowerUp = newTime;
                    startTimer = false;
                }
            }
        }

        public void AddFever(bool add, int factorSpeed,bool division)
        {
            startTimer = true;
            destructibleSnack.IndestructibleSnack(add);
            inputPlayer.SuperSpeed(factorSpeed, division);
        }
    }
}