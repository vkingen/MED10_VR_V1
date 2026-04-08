using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material materialToChangeTo;

    public void Change(SkinnedMeshRenderer sMR)
    {
        sMR.GetComponent<MaterialReference>().material = materialToChangeTo;
    }



}
