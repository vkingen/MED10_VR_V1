using BNG;
using UnityEngine;
using UnityEngine.Events;

public class Trashcan : MonoBehaviour
{
    public string otherTag;

    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(otherTag))
        {
            Grabbable g = other.GetComponent<Grabbable>();
            if (g != null)
            {
                Destroy(g.gameObject);
            }
            onTrigger.Invoke();
        }
    }
}
