using UnityEngine;

namespace _Scripts.UI
{
    public class UIWorldManager : MonoBehaviour
    {
        [SerializeField] private float m_distanceForUiToAppear;
        public static UIWorldManager Instance { get; private set;}

        public GameObject NpcHealthBars;
        public float DistanceForUIToAppear => m_distanceForUiToAppear;
   
        private void Awake() 
        { 
            // If there is an instance, and it's not me, delete myself.
    
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }
            
        }
    }
}
