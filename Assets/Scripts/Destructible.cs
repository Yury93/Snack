using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Snake
{
    public class Destructible : Entity
    {
        #region Properties
        
        [SerializeField] private bool m_Indestructible;
        public bool Indestructible => m_Indestructible;
        [SerializeField]private int m_HitPoints;
        [SerializeField] private float timeDestroy;
        [SerializeField] private bool bonus;
        public bool bonusPick => bonus;
        private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;
        #endregion

        #region Unity Events 
        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;

        protected virtual void Start()
        {
            m_CurrentHitPoints = HitPoints;
        }
        #endregion

        #region  Public API


        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;
            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
            {
                OnDeath();
            }
        }
        #endregion

      
        protected virtual void OnDeath()
        {
            StartCoroutine(corTimeDeath());
            m_EventOnDeath?.Invoke();
        }
        public void IndestructibleSnack(bool destr)
        {
            m_Indestructible = destr;
        }

        IEnumerator corTimeDeath()
        {
            yield return new WaitForSeconds(timeDestroy);
            Destroy(gameObject);
        }
    }
}
