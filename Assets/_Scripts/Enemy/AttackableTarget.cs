using UnityEngine;

namespace _Scripts.Enemy
{
    public class AttackableTarget : MonoBehaviour
    {
        [SerializeField] private int m_health;

        public void Attack(int damage)
        {
            m_health -= damage;
            
            if(m_health < 0)
                DoDeath();
        }

        private void DoDeath()
        {
            Debug.Log($"{gameObject.name} died.");
        }
    }
}
