using UnityEngine;

public class SnapDetachHandler : MonoBehaviour
{
    [Header("Tekst der skal aktiveres")]
    public GameObject textToActivate;

    [Header("Tekst der skal fjernes")]
    public GameObject textToDeactivate;

    private bool hasBeenGrabbedByUser = false;

    // Kald denne når brugeren grabber inderkanylen
    public void RegisterGrab()
    {
        hasBeenGrabbedByUser = true;
    }

    // Kald denne fra SnapZone On Detach
    public void HandleDetach()
    {
        if (!hasBeenGrabbedByUser)
            return;

        if (textToDeactivate != null)
            textToDeactivate.SetActive(false);

        if (textToActivate != null)
            textToActivate.SetActive(true);
    }
}