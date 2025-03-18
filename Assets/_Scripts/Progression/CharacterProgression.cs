using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CharacterProgression : MonoBehaviour
{
    [SerializeField] private float m_experienceIncreaseMultiplier;
    [SerializeField] private int m_startExperienceToLevelUp = 100;
    
    private int m_currentExperience;
    private int m_experienceToLevelUp;
    private int m_level;

    public int Level => m_level;

    [SerializeField] private UnityEvent m_hasLeveledUp;
    
    void Start()
    {
        m_experienceToLevelUp = m_startExperienceToLevelUp;
        UIManager.Instance.GetUICharacterProgression().UpdateExperienceSliderMaxValue(m_experienceToLevelUp);
    }

    public void GainExperience(int exp)
    {
        m_currentExperience += exp;

        if (m_currentExperience > m_experienceToLevelUp)
        {
            m_currentExperience -= m_experienceToLevelUp;
            m_experienceToLevelUp = Mathf.RoundToInt(m_experienceToLevelUp * m_experienceIncreaseMultiplier);
            UIManager.Instance.GetUICharacterProgression().UpdateExperienceSliderMaxValue(m_experienceToLevelUp);
            
            m_level++;
            m_hasLeveledUp.Invoke();
        }
        
        UIManager.Instance.GetUICharacterProgression().UpdateExperienceSliderValue(m_currentExperience);
    }

    public void OnDebugButton(InputValue value)
    {
        UIManager.Instance.GetUIHealthAndManaManager().Heal(10);
        UIManager.Instance.GetUIHealthAndManaManager().GainMana(10);
        GainExperience(100);
    }
}
