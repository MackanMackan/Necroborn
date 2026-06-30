using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemBase : ScriptableObject
{
    [SerializeField] private Sprite m_itemIcon;
    [SerializeField] private string m_itemID;
    [SerializeField] private int m_maxStackSize;
    [SerializeField] private int m_value;
    [SerializeField, TextArea] private string m_toolTip;
    
    public Sprite ItemIcon => m_itemIcon;
    public string ItemID => m_itemID;
    public int MaxStackSize => m_maxStackSize;
    public int Value => m_value;
    public string ToolTip => m_toolTip;
}
