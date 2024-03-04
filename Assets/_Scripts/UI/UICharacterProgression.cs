using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterProgression : MonoBehaviour
{
    [SerializeField] private Slider m_experienceMeter;
    [SerializeField] private TMP_Text m_experienceText;

    private const string k_divider = " / ";

    public void UpdateExperienceSliderValue(int value)
    {
        m_experienceMeter.value = value;
        UpdateExperienceText();
    }

    public void UpdateExperienceSliderMaxValue(int value)
    {
        m_experienceMeter.maxValue = value;
        UpdateExperienceText();
    }

    private void UpdateExperienceText()
    {
        m_experienceText.text = m_experienceMeter.value + k_divider + m_experienceMeter.maxValue;
    }
}
