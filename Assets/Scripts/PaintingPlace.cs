
using UnityEngine;

namespace Snake
{
    public class PaintingPlace : MonoBehaviour
    {
        [SerializeField] private MeshRenderer ColorMat;
        [SerializeField] private ParticleSystem[] particleSystems;
        [SerializeField] private Color colorPlace;
        public Color color => colorPlace;

        private void Awake()
        {
            ColorMat.GetComponent<MeshRenderer>().material.color = color;
            for (int i = 0; i < particleSystems.Length; i++)
            {
                particleSystems[i].GetComponent<ParticleSystem>().startColor = color;
            }
        }
    }
}