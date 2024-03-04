using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthAndManaManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider m_healthMeter;
    [SerializeField] private TMP_Text m_healthText;
    
    [Header("Mana")]
    [SerializeField] private Slider m_manaMeter;
    [SerializeField] private TMP_Text m_manaText;

    public void TakeDamage(int damage)
    {
        if (damage < 1) return;
        
        int newHealth = (int) m_healthMeter.value - damage;
        m_healthMeter.value = newHealth <= 0 ? 0 : newHealth;

        m_healthText.text = "" + m_healthMeter.value;
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 1) return;

        int newHealth = (int) m_healthMeter.value + healAmount;
        m_healthMeter.value = newHealth > m_healthMeter.maxValue ? m_healthMeter.maxValue : newHealth;
        
        m_healthText.text = "" + m_healthMeter.value;
    }

    // Use bool to check if the spell succeeds when casting
    public bool UseMana(int amount)
    {
        if (amount > m_manaMeter.value) return false;

        int newMana = (int)m_manaMeter.value - amount;
        m_manaMeter.value = newMana;

        m_manaText.text = "" + m_manaMeter.value;
        return true;
    }

    public void GainMana(int amount)
    {
        int newMana = (int)m_manaMeter.value + amount;
        
        m_manaMeter.value = newMana > m_manaMeter.maxValue ? m_manaMeter.maxValue : newMana;
        m_manaText.text = "" + m_manaMeter.value;
    }
}
