using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class FoodProperties : MonoBehaviour
    {
        [SerializeField] private GameObject goFood;
        private SkinnedMeshRenderer mesh;
        [SerializeField] private Color colorFood;
        public Color color => colorFood;

        [SerializeField] private PaintingPlace paintingPlace;
        [SerializeField] private bool copyColorPaintingPlace = false;

        
        /// <summary>
        /// Someone eats
        /// </summary>
        [SerializeField] private GameObject snake;
        private void Start()
        {
            if (copyColorPaintingPlace == true)
            {
                colorFood = paintingPlace.color;
            }
            mesh = goFood.GetComponentInChildren<SkinnedMeshRenderer>();
            if (mesh != null)
            {
                mesh.material.color = colorFood;
            }
        }
    }
}
