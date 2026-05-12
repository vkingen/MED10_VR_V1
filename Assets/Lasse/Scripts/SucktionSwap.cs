using BNG;
using UnityEngine;

public class SucktionSwap : MonoBehaviour
{
    public Grabbable sucktionHose;
    public SnapZone sucktionAddSnapZone;

    public void Swap()
    {
        sucktionAddSnapZone.GrabGrabbable(sucktionHose);
    }
}
