using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isEnabled = true;

    public Action onInteract;

    public void Interact()
    {
        if (!isEnabled)
        {
            Debug.Log($"{name} is disabled");
            return;
        }

        Debug.Log($"{name} interacted");
        onInteract?.Invoke();
    }

    public void Enable()
    {
        isEnabled = true;
        gameObject.SetActive(true); // optional
    }

    public void Disable()
    {
        isEnabled = false;
        // You can also gray out, remove collider, etc.
    }
}