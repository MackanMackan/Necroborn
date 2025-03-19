using _Scripts.Enemy;
using _Scripts.Summon;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class GiveCommands : MonoBehaviour
    {
        [Header("Protect Area")]
        [SerializeField] private GameObject m_protectBanner;
        [SerializeField] private float m_bannerFallHeight = 10f;
        [SerializeField] private float m_bannerFallDuration = 1f;
        [SerializeField] private float m_bannerShakeDuration = 0.5f;
        
        public UnityEvent<(ICommand, GameObject)> DoCommand;
        private RaycastHit[] m_rayHit = new RaycastHit[1];
        private Transform m_cameraTransform;
        private Transform m_myTransform;
        private bool m_bannerActive;
        
        void Start()
        {
            m_cameraTransform = PlayerAccessibles.Instance.MainCamera.transform;
            m_myTransform = transform;
        }

        public void OnAttackCommand()
        {
            if (m_bannerActive)
                ReturnBanner();
            
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
            if (m_bannerActive)
                ReturnBanner();
            
            DoCommand.Invoke((new FollowCommand(), gameObject));
        }

        public void OnProtectAreaCommand()
        {
            bool hit = Physics.Raycast(m_cameraTransform.position, m_cameraTransform.forward, out RaycastHit hitInfo, 100f, 1 << LayerMask.NameToLayer("Ground"));

            if(hit)
            {
                Debug.Log($"Protecting Area");
                Vector3 protectPosition = hitInfo.point;
                if (!m_bannerActive)
                {
                    SummonBanner(protectPosition);
                    m_bannerActive = true;
                }
                else
                {
                    m_protectBanner.transform.position = protectPosition;
                }
                
                DoCommand.Invoke((new ProtectAreaCommand(), m_protectBanner));
            }
        }
        
        private void SummonBanner(Vector3 position)
        {
            m_protectBanner.transform.position = position;
            m_protectBanner.transform.parent = null;
            Vector3 targetPosition = m_protectBanner.transform.position;
            targetPosition += Vector3.up * m_bannerFallHeight;
            m_protectBanner.transform.position = targetPosition;
            m_protectBanner.transform.gameObject.SetActive(true);
            m_protectBanner.transform.DOMoveY((targetPosition.y + -1 * m_bannerFallHeight), m_bannerFallDuration).OnComplete(() =>
            {
                m_protectBanner.transform.DORotateQuaternion(Quaternion.identity, m_bannerShakeDuration).SetEase(Ease.OutElastic);
            });
        }
        
        private void ReturnBanner()
        {
            m_bannerActive = false;
            m_protectBanner.transform.parent = null;
            Vector3 targetFlightPosition = m_protectBanner.transform.position;
            targetFlightPosition += Vector3.up * m_bannerFallHeight;
            m_protectBanner.transform.gameObject.SetActive(true);
            m_protectBanner.transform.DOMoveY(targetFlightPosition.y, m_bannerFallDuration);
            m_protectBanner.transform.DORotateQuaternion(Quaternion.AngleAxis(360, Vector3.up), m_bannerFallDuration)
                .OnComplete(() =>
                {
                    m_protectBanner.transform.position = m_myTransform.position;
                    m_protectBanner.transform.parent = m_myTransform;
                    m_protectBanner.transform.gameObject.SetActive(false);
                });
        }
    }
}
