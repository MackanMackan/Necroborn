using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class FollowCommand : ICommand
    {
        private Transform m_target;
        private NavMeshAgent m_agent;
        private AIAnimationController m_animationController;
        
        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self)
        {
            m_target = target;
            m_agent = agent;
            m_animationController = animationController;
            Debug.Log($"{self} is following {target}");
        }

        public void Execute()
        {
            if(m_target == null) return;

           FollowTarget();
        }

        public void Uninitialize()
        {

        }

        public void FollowTarget(Transform target, NavMeshAgent agent, AIAnimationController animationController)
        {
            agent.SetDestination(target.position);
            animationController.RunAnimation(agent.velocity);
        }

        private void FollowTarget()
        {
            FollowTarget(m_target, m_agent, m_animationController);
        }
    }
}
