using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        
        private readonly int m_animSpeed = Animator.StringToHash("Speed");
        private readonly int m_animCommand = Animator.StringToHash("Command");
        private readonly int m_animAttack = Animator.StringToHash("Attack");
        private readonly int m_animSprint = Animator.StringToHash("Sprinting");

        public void OnSprint(InputValue value)
        {
            m_animator.SetBool(m_animSprint, value.isPressed);
        }

        // From Third person controller
        public void RunAnimation(float speed)
        {
            m_animator.SetFloat(m_animSpeed, speed);
        }

        // Event from Give Command Script
        public void GiveCommandAnimation()
        {
            m_animator.SetTrigger(m_animCommand);
        }

        public void AttackAnimation()
        {
            m_animator.SetTrigger(m_animAttack);
        }
        
    }
}
