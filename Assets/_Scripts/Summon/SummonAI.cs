using System;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class SummonAI : MonoBehaviour
    {
        [Header("Stats")]
        
        [SerializeField] private int m_health = 10;
        [SerializeField] private int m_damage = 10;
        [SerializeField] private float m_attackSpeed = 2;
        [SerializeField] private float m_aggroRange = 5;
        
        [Space]
        [SerializeField] private NavMeshAgent m_aiAgent;
        [SerializeField] private Transform m_target;
        [SerializeField] private AIAnimationController m_animController;

        private ICommand m_activeCommand;

        public int Health => m_health;
        public int Damage => m_damage;
        public float AttackSpeed => m_attackSpeed;
        public float AggroRange => m_aggroRange;

        private void Start()
        {
            PlayerAccessibles.Instance.GiveCommands.DoCommand.AddListener(SetNewCommand);
            
            m_activeCommand = new FollowCommand();
            m_activeCommand.Initialize(m_target, m_aiAgent, m_animController, transform);
        }

        void Update()
        {
            if (m_activeCommand == null) return;
            
            m_activeCommand.Execute();
        }

        public void SetNewCommand((ICommand,  GameObject) command)
        {
            Debug.Log($"{transform} got command {command}");
            m_activeCommand.Uninitialize();
            m_activeCommand = CommandLookUp(command.Item1);
            m_activeCommand.Initialize(command.Item2.transform, m_aiAgent, m_animController, transform);
        }

        private ICommand CommandLookUp(ICommand command) => command switch
        {
            AttackCommand => new AttackCommand(),
            FollowCommand => new FollowCommand(),
            ProtectAreaCommand => new ProtectAreaCommand(),
            _ => new FollowCommand()
        };

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_aggroRange);
        }
    }
}
