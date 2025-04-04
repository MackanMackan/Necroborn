using UnityEngine;

namespace _Scripts.Summon
{
    public class AIAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private readonly int m_animSpeed = Animator.StringToHash("Speed");
        private readonly int m_animAttack = Animator.StringToHash("Attack");
        private readonly int m_animAttackSpeed = Animator.StringToHash("AttackSpeed");
 
        public void RunAnimation(Vector3 velocity)
        {
            animator.SetFloat(m_animSpeed, velocity.sqrMagnitude);
        }

        public void AttackAnimation(float attackSpeed)
        {
            animator.SetFloat(m_animAttackSpeed, attackSpeed);
            animator.SetTrigger(m_animAttack);
        }
    }
}
