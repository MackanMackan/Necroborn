using _Scripts.Enemy;
using _Scripts.Player;
using _Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class UINpcHealth : MonoBehaviour
    {
        [SerializeField] private Slider m_healthBar;
        [SerializeField] private float m_uiHealthBarPlacementUpwards = 2f;
        
        private AttackableTarget m_attackableTarget;

        private Transform m_player;
        private Transform m_thisTransform;
        private void Start()
        {
            m_attackableTarget = GetComponent<AttackableTarget>();
            m_attackableTarget.OnHit.AddListener(UpdateHealthBar);
            m_player = PlayerAccessibles.Instance.transform;
            m_thisTransform = transform;
            m_healthBar.maxValue = m_attackableTarget.BaseHealth;
            m_healthBar.value = m_healthBar.maxValue;
        }

        private void OnEnable()
        {
            if(m_healthBar == null) return;
            m_healthBar.transform.SetParent(UIWorldManager.Instance.NpcHealthBars.transform);
        }
        
        // private void OnDisable()
        // {
        //     if(m_healthBar == null) return;
        //     m_healthBar.transform.SetParent(transform);
        // }

        private void Update()
        {
            ActivateUIOnDistance();
            UpdateUIMovement();
        }

        private void UpdateHealthBar()
        {
            m_healthBar.value = m_attackableTarget.Health;
        }

        private void ActivateUIOnDistance()
        {
            float distanceToPlayer = (m_thisTransform.position - m_player.position).sqrMagnitude;
            if (distanceToPlayer < UIWorldManager.Instance.DistanceForUIToAppear.Squared() && !m_healthBar.isActiveAndEnabled)
            {
                Debug.LogError("Activate ui");
                m_healthBar.gameObject.SetActive(true);
            }
            else if (distanceToPlayer > UIWorldManager.Instance.DistanceForUIToAppear.Squared() && m_healthBar.isActiveAndEnabled)
            {
                m_healthBar.gameObject.SetActive(false);
            }
        }

        private void UpdateUIMovement()
        {
            if (!m_healthBar.isActiveAndEnabled) return;
            Vector3 uiPosition = transform.position + Vector3.up * m_uiHealthBarPlacementUpwards;
            uiPosition = PlayerAccessibles.Instance.MainCamera.WorldToScreenPoint(uiPosition);
            m_healthBar.transform.position = uiPosition;
        }
    }
}
