using System.Collections;
using UnityEngine;

public class HideWithDelay : MonoBehaviour
{
    public float delayTime;
    private void Start()
    {
        StartCoroutine(Hide());
    }



    IEnumerator Hide()
    {
        yield return new WaitForSeconds(delayTime);
        this.gameObject.SetActive(false);
    }
}
