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
            m_activeCommand.Initialize(m_target, m_aiAgent, m_animController);
        }

        void Update()
        {
            if (m_activeCommand == null) return;
            
            m_activeCommand.Execute();
        }

        private void SetNewCommand(ICommand command)
        {
            m_activeCommand.Uninitialize();
            m_activeCommand = command;
            m_activeCommand.Initialize(m_target, m_aiAgent, m_animController);
        }
    }
}
