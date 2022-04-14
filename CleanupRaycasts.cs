using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Sirenix.OdinInspector;

//Dan G.

[ExecuteAlways]
public class CleanupRaycasts : MonoBehaviour
{
    [Header("Set this True, and Restart Script")]
    public bool EnableScript = false;
    [Header("Images")]
    public bool DisableImageRaycasts = false;
    [Header("Text")]
    public bool DisableTextMeshProTextRaycasts = false;
    
    void OnEnable() 
    {
        if (!EnableScript) { return; }
        ClearRaycasts(); 
    }

    //[Button]
    void ClearRaycasts()
    {
        if (DisableImageRaycasts)
        {
            Image[] Cols = transform.GetComponentsInChildren<Image>();

            int RemovedCount = 0;
            int IgnoredCount = 0;
            int Count = Cols.Length;
            for (int i = 0; i < Count; i++)
            {
                UnityEngine.UI.Image Img = Cols[i];
                if (Img.raycastTarget)
                {
                    //Ignore Common Event System Tools
                    IgnoredCount++;
                    GameObject Go = Img.gameObject;
                    if (Go.GetComponent<Button>() != null) continue;
                    if (Go.GetComponent<InputField>() != null) continue;
                    if (Go.GetComponent<Scrollbar>() != null) continue;
                    if (Go.GetComponent<ScrollRect>() != null) continue;
                    if (Go.GetComponent<Slider>() != null) continue;
                    if (Go.GetComponent<Toggle>() != null) continue;
                    if (Go.GetComponent<UnityEngine.EventSystems.EventTrigger>() != null) continue;
                    IgnoredCount--;

                    RemovedCount++;
                    Img.raycastTarget = false;
                }
            }
            Debug.Log("Image Raycasts Removed + " + RemovedCount);
            Debug.Log("Image Raycasts Ignored + " + IgnoredCount);
        }

        if (DisableTextMeshProTextRaycasts)
        {
            TMPro.TextMeshProUGUI[] Texts = transform.GetComponentsInChildren<TMPro.TextMeshProUGUI>();

            int RemovedCount = 0;
            int IgnoredCount = 0;
            int Count = Texts.Length;
            for (int i = 0; i < Count; i++)
            {
                TMPro.TextMeshProUGUI Text = Texts[i];
                if (Text.raycastTarget)
                {
                    RemovedCount++;
                    Text.raycastTarget = false;
                }
            }
            Debug.Log("Text Raycasts Removed + " + RemovedCount);
            Debug.Log("Text Raycasts Ignored + " + IgnoredCount);
        }

        EnableScript = false;
    }
}
