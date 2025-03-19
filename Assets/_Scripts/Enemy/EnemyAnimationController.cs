using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private int m_animDead = Animator.StringToHash("Dead");
        private int m_animHit = Animator.StringToHash("Hit");

        public void DeadAnimation()
        {
            animator.SetTrigger(m_animDead);
        }

        public void HitAnimation()
        {
            animator.SetTrigger(m_animHit);
        }
    }
}
