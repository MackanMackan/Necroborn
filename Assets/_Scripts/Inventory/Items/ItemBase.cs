using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemBase : ScriptableObject
{
    [SerializeField] private string m_itemID;
    [SerializeField] private int m_maxStackSize;
    [SerializeField] private Sprite m_itemIcon;
}
