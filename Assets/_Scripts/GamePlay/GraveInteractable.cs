using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject m_explotionObject;
    public void AimedOn()
    {
    }

    public void Interact()
    {
        m_explotionObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
