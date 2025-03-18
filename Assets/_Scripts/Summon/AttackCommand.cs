using _Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class AttackCommand : ICommand
    {
        private Transform m_target;
        private Transform m_selfTransform;
        private NavMeshAgent m_agent;
        private AIAnimationController m_animationController;
        private AttackableTarget m_attackableTarget;
        
        private float m_turnSpeed = 20.0f;
        private float m_attackSpeed = 3.0f;
        private int m_attackDamage = 5;
        private float m_timeCounter = 0f;

        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self)
        {
            m_target = target;
            m_agent = agent;
            m_animationController = animationController;
            m_selfTransform = self;
            m_attackableTarget = target.GetComponent<AttackableTarget>();
        }

        public void Execute()
        {
            if(m_target == null) return;

            m_timeCounter += Time.deltaTime;
            
            // Out of range
            
            m_agent.SetDestination(m_target.position);
            m_animationController.RunAnimation(m_agent.velocity);
          

            if(m_agent.velocity.magnitude > 0.15f) return;
            
            //Rotates towards target while in attack
            Quaternion rotation = m_selfTransform.rotation;
            rotation = Quaternion.RotateTowards(new Quaternion(0, rotation.y, 0, rotation.w), 
                Quaternion.LookRotation(m_target.position-m_selfTransform.position, Vector3.up),m_turnSpeed);
            m_selfTransform.rotation = rotation;
            
            // Attack on cooldown
            if(m_timeCounter < m_attackSpeed) return;
            
            m_animationController.AttackAnimation();
            m_attackableTarget.Attack(m_attackDamage);
            m_timeCounter = 0;
            Debug.Log($"{m_selfTransform} Attacked {m_target}");
            
        }

        public void Uninitialize()
        {
            
        }
    }
}
