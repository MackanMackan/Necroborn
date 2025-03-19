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
        private FollowCommand m_followCommand;
        
        private float m_turnSpeed = 20.0f;
        private float m_timeCounter = 0f;
        private SummonAI m_summonAI;

        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self)
        {
            m_target = target;
            m_agent = agent;
            m_animationController = animationController;
            m_selfTransform = self;
            m_attackableTarget = target.GetComponent<AttackableTarget>();
            m_summonAI = m_selfTransform.GetComponent<SummonAI>();
            m_followCommand = new FollowCommand();
        }

        public void Execute()
        {
            if(m_target == null) return;
            
            m_followCommand.FollowTarget(m_target, m_agent, m_animationController);

            AttackTarget();

        }

        public void Uninitialize()
        {
            
        }

        public void AttackTarget(Transform target, AttackableTarget attackableTarget, NavMeshAgent agent, 
            Transform self, SummonAI summonAi, AIAnimationController animationController)
        {
            m_timeCounter += Time.deltaTime;

            // Check if agent is almost still, to indicate it is close enough to attackn change this if you have ranged units
            if(agent.velocity.magnitude > 0.15f) return;
            
            //Rotates towards target while in attack
            Quaternion rotation = self.rotation;
            rotation = Quaternion.RotateTowards(new Quaternion(0, rotation.y, 0, rotation.w), 
                Quaternion.LookRotation(target.position-self.position, Vector3.up),m_turnSpeed);
            self.rotation = rotation;
            
            // Attack on cooldown
            if(m_timeCounter < summonAi.AttackSpeed) return;
            
            // Coverts to attacks per second
            animationController.AttackAnimation(1/summonAi.AttackSpeed);
            attackableTarget.Attack(summonAi.Damage);
            m_timeCounter = 0;
        }

        private void AttackTarget()
        {
            AttackTarget(m_target, m_attackableTarget, m_agent, m_selfTransform, m_summonAI, m_animationController);
        }
    }
}
