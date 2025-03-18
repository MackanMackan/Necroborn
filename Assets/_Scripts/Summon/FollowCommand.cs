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

            m_agent.SetDestination(m_target.position);
            m_animationController.RunAnimation(m_agent.velocity);
        }

        public void Uninitialize()
        {

        }
    }
}
