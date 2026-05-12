using BNG;
using UnityEngine;

public class SyrringeSwap : MonoBehaviour
{
    public Grabbable syrringe;
    public SnapZone syrringeAddSnapZone;

    public void Swap()
    {
        syrringeAddSnapZone.GrabGrabbable(syrringe);
    }
}
