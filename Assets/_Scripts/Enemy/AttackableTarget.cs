using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Enemy
{
    public class AttackableTarget : MonoBehaviour
    {
        [SerializeField] private int m_health;
        [SerializeField] private ParticleSystem m_damagedParticles;

        private bool m_isDead;
        public UnityEvent OnDead;
        public UnityEvent OnHit;

        public void Attack(int damage)
        {
            if(m_isDead) return;
            
            m_health -= damage;
            OnHit?.Invoke();

            if (m_health < 0)
            {
                DoDeath();
                m_isDead = true;
            }
            
            if(m_damagedParticles == null) return;
            m_damagedParticles.Play();
        }

        private void DoDeath()
        {
            OnDead!.Invoke();
            Debug.Log($"{gameObject.name} died.");
        }
    }
}
