using UnityEngine;

namespace _Scripts.Summon
{
    public class AIAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private int m_animSpeed = Animator.StringToHash("Speed");
        private int m_animAttack = Animator.StringToHash("Attack");
 
        public void RunAnimation(Vector3 velocity)
        {
            animator.SetFloat(m_animSpeed, velocity.sqrMagnitude);
        }

        public void AttackAnimation()
        {
            animator.SetTrigger(m_animAttack);
        }
    }
}
