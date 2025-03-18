using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerAccessibles : MonoBehaviour
    {
        public GiveCommands GiveCommands;
        public Camera MainCamera;
        
        public static PlayerAccessibles Instance => s_instance;
        private static PlayerAccessibles s_instance;

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
    }
}
