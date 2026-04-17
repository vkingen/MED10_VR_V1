using UnityEngine;

public class InnerCannula : MonoBehaviour
{
    [SerializeField]
    private GameObject dirtObject;

    //Cleaning the canulla at the sink
    public void Clean()
    {
        if (dirtObject != null)
        {
            dirtObject.SetActive(false);
        }
    }
}
