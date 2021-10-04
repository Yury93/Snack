using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class PlayerStatistics : MonoBehaviour
    {
        [SerializeField] private Text numFood;
        [SerializeField] private Text numCrystal;

        public  int numberFood;
        public int numberCrystal;

        public void BroadcastStatistic()
        {
                numFood.text = numberFood.ToString();
                numCrystal.text = numberCrystal.ToString();
        }
        private void Reset()
        {
            numberFood = 0;
            numberCrystal = 0;
        }
    }
}