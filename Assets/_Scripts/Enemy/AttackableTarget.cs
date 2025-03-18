using UnityEngine;

namespace _Scripts.Enemy
{
    public class AttackableTarget : MonoBehaviour
    {
        [SerializeField] private int m_health;
        [SerializeField] private ParticleSystem m_damagedParticles;

        public void Attack(int damage)
        {
            m_health -= damage;
            if(m_health < 0)
                DoDeath();
            
            if(m_damagedParticles == null) return;
            m_damagedParticles.Play();
        }

        private void DoDeath()
        {
            Debug.Log($"{gameObject.name} died.");
        }
    }
}
