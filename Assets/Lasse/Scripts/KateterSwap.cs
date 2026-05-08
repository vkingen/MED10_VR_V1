using BNG;
using System.Collections;
using UnityEngine;

public class KateterSwap : MonoBehaviour
{
    public SnapZone kateterSnap;
    public Grabbable kateter;
    public GameObject kateterUpper;

    public void Swap()
    {
        StartCoroutine(Delay());
        
    }

    IEnumerator Delay()
    {
        // Wait....

        yield return new WaitForSeconds(0.1f);
        
        kateterSnap.ReleaseAll();
        kateterUpper.SetActive(true);
        kateterUpper.transform.parent = null;

        kateter.transform.position = kateterSnap.transform.position;
        kateterSnap.GrabGrabbable(kateter);
    }


    /*
     // Auto Equip item by moving it into place and grabbing it
            if (StartingItem != null) {
                StartingItem.transform.position = transform.position;
                GrabGrabbable(StartingItem);
            }
     */
}
