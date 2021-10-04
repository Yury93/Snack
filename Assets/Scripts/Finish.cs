
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
                SceneManager.LoadScene(0);
            
        }
    }
}