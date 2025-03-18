using _Scripts.Summon;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class GiveCommands : MonoBehaviour
    {
        public UnityEvent<ICommand> DoCommand;
        private RaycastHit[] m_rayHit = new RaycastHit[1];

        void Start()
        {
        
        }


        void Update()
        {
        
        }

        public void OnGiveCommand()
        {
            int hits = Physics.RaycastNonAlloc(m_cameraTransform.position, m_cameraTransform.forward, m_rayHit, 100f, 1 << LayerMask.NameToLayer("Interactable"));

            if(hits > 0)
            {
                if(m_rayHit[0].transform.TryGetComponent(out IInteractable interactable))
                {
                    interactable.AimedOn();

                    if (_input.isFiring)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
