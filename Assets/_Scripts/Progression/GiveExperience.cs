using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Progression
{
    public class GiveExperience : MonoBehaviour
    {
        [SerializeField] private int m_experienceGain;
        
        public void GivePlayerExperience()
        {
            PlayerAccessibles.Instance.CharacterProgression.GainExperience(m_experienceGain);
        }
    }
}
