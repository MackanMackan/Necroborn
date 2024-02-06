using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public static UIManager Instance { get; private set;}

   private ResourceManager m_resourceManager;
   private UICharacterProgression m_uiCharacterProgression;
   
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

       GetChildUIManagers();
   }

   private void GetChildUIManagers()
   {
       m_resourceManager = GetComponentInChildren<ResourceManager>();
       m_uiCharacterProgression = GetComponentInChildren<UICharacterProgression>();
   }

   public ResourceManager GetResourceManager() => m_resourceManager;
   public UICharacterProgression GetUICharacterProgression() => m_uiCharacterProgression;
}
