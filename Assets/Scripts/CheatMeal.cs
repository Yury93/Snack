using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class CheatMeal : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer[] meshRenderer;
        private PaintingPlace paintPlace;
        [SerializeField] private Destructible snackDestr;
        [SerializeField] private PlayerStatistics playerStatistics;
        private int crystalFever = 0;
       [SerializeField] private PowerUp powerUp;
    
       
        #region Triggers
        private void OnTriggerEnter(Collider other)
        {
            var des = other.GetComponent<Destructible>();
            var foodProp = other.GetComponent<FoodProperties>();

            if (powerUp.startTimerFever == true && des != null)
            {
                playerStatistics.numberFood += 1;
                des.ApplyDamage(1);
            }

            if (des != null && foodProp != null)
            {
                if (des.bonusPick == false)
                {
                    if (foodProp.color == meshRenderer[0].material.color)
                    {
                        playerStatistics.numberFood += 1;
                        crystalFever = 0;
                        playerStatistics.BroadcastStatistic();
                        des.ApplyDamage(1);
                    }
                    else if (snackDestr.Indestructible == false && foodProp.color != meshRenderer[0].material.color)
                    {
                        crystalFever = 0;
                        //snackDestr.ApplyDamage(1);
                        gameObject.SetActive(false);
                        SceneManager.LoadScene(0);
                    }
                }
                else
                {
                    playerStatistics.numberCrystal += 1;
                    crystalFever += 1;
                    if (crystalFever >= 3)
                    {
                        powerUp.AddFever(true, 3, true);
                        crystalFever = 0;
                    }
                    playerStatistics.BroadcastStatistic();
                    des.ApplyDamage(1);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            paintPlace = other.GetComponent<PaintingPlace>();
            if (paintPlace != null)
            {
                for (int i = 0; i < meshRenderer.Length; i++)
                {
                    meshRenderer[i].material.color = paintPlace.color;
                }
            }
        }
        #endregion
        private void SetCheatMeal(PlayerStatistics playerStat, PowerUp power)
        {
            playerStatistics = playerStat;
            powerUp = power; 
        }
    }
}