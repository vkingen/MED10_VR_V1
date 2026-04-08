using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvents : MonoBehaviour
{
    public string otherTag;
    public UnityEvent onTriggerEvent;
    public Material materialToChangeTo;
    public bool changeMaterial;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(otherTag))
        {
            onTriggerEvent.Invoke();
            if (changeMaterial)
            {
                ChangeMaterial(other.GetComponent<MaterialReference>().skinnedMeshRenderer);
            }
        }
    }

    public void ChangeMaterial(SkinnedMeshRenderer sMR)
    {
        sMR.material = materialToChangeTo;
    }

}


