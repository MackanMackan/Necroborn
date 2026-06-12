using UnityEngine;
using UnityEngine.Events;

public class InputForwarder : MonoBehaviour
{
    public UnityEvent OnInventoryToggled;

    public void OnToggleInventory()
    {
        OnInventoryToggled?.Invoke();
    }
}
