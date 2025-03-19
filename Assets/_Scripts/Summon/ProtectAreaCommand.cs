using _Scripts.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class ProtectAreaCommand : ICommand
    {
        private Transform m_target;
        private NavMeshAgent m_agent;
        private AIAnimationController m_animationController;
        private Transform m_player;
        private Transform m_activeAttackTarget;
        private bool m_isAttacking;
        
        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self)
        {
            m_target = target;
            m_agent = agent;
            m_animationController = animationController;
            m_player = PlayerAccessibles.Instance.transform;
        }

        public void Execute()
        {
            if(m_target == null) return;

            if (m_isAttacking)
            {   
                FollowTarget(m_activeAttackTarget);
            }
            else
            {
                FollowTarget(m_target);
            }
        }

        public void Uninitialize()
        {
            
        }

        private void FollowTarget(Transform target)
        {
            m_agent.SetDestination(target.position);
            m_animationController.RunAnimation(m_agent.velocity);
        }

        private void AttackTargetInProximity()
        {
            
        }
    }
}
