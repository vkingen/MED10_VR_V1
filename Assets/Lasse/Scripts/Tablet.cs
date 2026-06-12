using TMPro;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    public TMP_Text[] buttonTexts;

    public void UpdateText(TMP_Text tmpText)
    {
        foreach (TMP_Text txt in buttonTexts)
        {
            if(txt == tmpText)
            {
                tmpText.fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
