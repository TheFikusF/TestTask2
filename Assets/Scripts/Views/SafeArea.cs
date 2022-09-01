using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private void Awake()
    {
        var safeArea = Screen.safeArea;
        var phoneScreen = GetComponent<RectTransform>();

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        phoneScreen.anchorMin = anchorMin;
        phoneScreen.anchorMax = anchorMax;
    }
}
