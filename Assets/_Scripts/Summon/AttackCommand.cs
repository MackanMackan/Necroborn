using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class AttackCommand : ICommand
    {
        private Transform m_target;
        private NavMeshAgent m_agent;
        private AIAnimationController m_animationController;

        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController)
        {
            m_target = target;
            m_agent = agent;
            m_animationController = animationController;
        }

        public void Execute()
        {
            
        }

        public void Uninitialize()
        {
            
        }
    }
}
