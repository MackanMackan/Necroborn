using _Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Bag Icon")]
    [SerializeField] private Image m_bagIcon;
    [SerializeField] private Sprite m_bagClosedIcon;
    [SerializeField] private Sprite m_bagOpenIcon;

    [Space]

    [Header("Inveontory")]
    [SerializeField] private GameObject m_inventoryImage;



    bool m_isOpen = false;

    private void Start()
    {
        PlayerAccessibles.Instance.InputForwarder.OnInventoryToggled.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        m_isOpen = !m_isOpen;

        if (m_isOpen)
        {
            m_bagIcon.sprite = m_bagOpenIcon;
            m_inventoryImage.SetActive(m_isOpen);
        }
        else
        {
            m_bagIcon.sprite = m_bagClosedIcon;
            m_inventoryImage.SetActive(m_isOpen);
        }
    }
}
