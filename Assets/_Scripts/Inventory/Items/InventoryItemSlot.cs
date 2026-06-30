using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private ItemBase m_item;
    [SerializeField] private Image m_itemImage;
    [SerializeField] private TMP_Text m_toolTipText;
    [SerializeField] private GameObject m_toolTipPanel;
    [SerializeField] private TMP_Text m_stackText;
    private int m_stack;

    private string m_valueText = "/nValue: ";
    private string m_coinText = "G";


    void Start()
    {
        AddItemToSlot(m_item,10);
    }


    void Update()
    {
        
    }

    // the return value is for the inventory manager to check if the item slot stack got full and need to place the reminder in another item slot.
    public int AddItemToSlot(ItemBase item, int amount)
    {
        int leftOverAmount = 0;
        if(m_item == null) {
            Debug.LogError("Item is null");
            return 0; 
        }

        if(m_stack + amount > item.MaxStackSize)
        {
            leftOverAmount = m_stack + amount - m_item.MaxStackSize;
            m_stack = m_item.MaxStackSize;
        }
        else
        {
            m_stack += amount;
        }

        if (m_item == null)
        {
            m_item = item;
            m_itemImage.sprite = item.ItemIcon;
        }
        m_item = item;
        m_itemImage.sprite = item.ItemIcon;

        m_toolTipText.text = item.ToolTip + m_valueText + m_coinText;
        m_toolTipPanel.SetActive(true);

        m_stackText.text = m_stack.ToString();
        
        return leftOverAmount;
    }

    public ItemBase GetItem() { return m_item; }
}


