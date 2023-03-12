using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_boneAmountText;
    [SerializeField] private TMP_Text m_soulAmountText;

    public static ResourceManager Instance => s_instance;
    private static ResourceManager s_instance;

    private int m_boneAmount;
    private int m_soulAmount;

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool AddBoneResource(int amount)
    {
        if(m_boneAmount + amount < 0)
        {
            Debug.LogWarning($"Not enough bones to remove.");
            return false;
        }

        m_boneAmount += amount;
        m_boneAmountText.text = m_boneAmount.ToString();
        return true;
    }

    public void RemoveBoneResource(int amount)
    {
        amount = Mathf.Abs(amount);
        AddBoneResource(-amount);
    } 

    public bool AddSoulResource(int amount)
    {
        if(m_soulAmount + amount < 0)
        {
            Debug.LogWarning($"Not enough bones to remove.");
            return false;
        }

        m_soulAmount += amount;
        m_soulAmountText.text = m_soulAmount.ToString();
        return true;
    }

    public void RemoveSoulResource(int amount)
    {
        amount = Mathf.Abs(amount);
        AddSoulResource(-amount);
    }
}
