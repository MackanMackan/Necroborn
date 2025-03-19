using _Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class ProtectAreaCommand : ICommand
    {
        private Transform m_targetToProtect;
        private Transform m_selfTransform;
        private NavMeshAgent m_agent;
        private AIAnimationController m_animationController;
        private AttackableTarget m_activeAttackTarget;
        private bool m_isAttacking;
        private float m_aggroRange;
        private SummonAI m_summonAI;
        private AttackCommand m_attackCommand;
        private FollowCommand m_followCommand;

        private Collider[] m_hitColliders = new Collider[10];
        
// TODO: Get navmesh aianimationcontroller and ush from SummonAI script directly
        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self)
        {
            m_targetToProtect = target;
            m_agent = agent;
            m_animationController = animationController;
            m_summonAI = self.GetComponent<SummonAI>();
            m_selfTransform = self;
            m_attackCommand = new AttackCommand();
            m_followCommand = new FollowCommand();
        }

        public void Execute()
        {
            if(m_targetToProtect == null) return;
            GetTargetInProximity();
            
            if (m_isAttacking)
            {   
                m_followCommand.FollowTarget(m_activeAttackTarget.transform, m_agent, m_animationController);
                m_attackCommand.AttackTarget(m_activeAttackTarget.transform, m_activeAttackTarget, m_agent,
                    m_selfTransform, m_summonAI, m_animationController);
            }
            else
            {
                m_followCommand.FollowTarget(m_targetToProtect, m_agent, m_animationController);
            }
        }

        public void Uninitialize()
        {
            
        }

        private void GetTargetInProximity()
        {
            int size = Physics.OverlapSphereNonAlloc(m_targetToProtect.position, m_summonAI.AggroRange, m_hitColliders, 1 << LayerMask.NameToLayer("Attackable"));

            if (size == 0 && m_isAttacking)
            {
                m_isAttacking = false;
                return;
            }
            
            if (size == 0) return;
            
            
            if (m_hitColliders[0].transform.root.TryGetComponent(out AttackableTarget attackableTarget))
            {
                m_activeAttackTarget = attackableTarget;
                m_isAttacking = true;
            }
        }
    }
}
