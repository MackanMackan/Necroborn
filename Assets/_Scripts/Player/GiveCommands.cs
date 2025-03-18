using _Scripts.Enemy;
using _Scripts.Summon;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class GiveCommands : MonoBehaviour
    {
        public UnityEvent<(ICommand, GameObject)> DoCommand;
        private RaycastHit[] m_rayHit = new RaycastHit[1];
        private Transform m_cameraTransform;
        
        void Start()
        {
            m_cameraTransform = PlayerAccessibles.Instance.MainCamera.transform;
        }

        public void OnAttackCommand()
        {
           int hits = Physics.RaycastNonAlloc(m_cameraTransform.position, m_cameraTransform.forward, m_rayHit, 100f, 1 << LayerMask.NameToLayer("Attackable"));

            if(hits > 0)
            {
                if (m_rayHit[0].transform.TryGetComponent(out AttackableTarget target))
                {
                    Debug.Log($"Attack target {target}");
                    DoCommand.Invoke((new AttackCommand(), target.gameObject));
                }
            }
        }

        public void OnFollowCommand()
        {
            Debug.Log($"Following...");
            DoCommand.Invoke((new FollowCommand(), gameObject));
        }
    }
}
