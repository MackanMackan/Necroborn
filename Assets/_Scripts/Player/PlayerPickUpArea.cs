using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpArea : MonoBehaviour
{
    public static PlayerPickUpArea Instance => s_instance;
    private static PlayerPickUpArea s_instance;

    public Transform PlayerTransform => transform;
    private void Awake()
    {
        if(s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            if(other.TryGetComponent(out IPickUpable pickup))
            {
                pickup.OnPickup();
            }
        }
    }
}
