using System;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public class SummonAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_aiAgent;
        [SerializeField] private Transform m_target;
        [SerializeField] private AIAnimationController m_animController;

        private ICommand m_activeCommand;

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

        private void SetNewCommand((ICommand,  GameObject) command)
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
    }
}
