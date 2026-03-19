using UnityEngine;

public class FrontMonitor : MonoBehaviour
{
    public GameObject errorImage;

    void Start()
    {
        errorImage.SetActive(false); // hide at start
    }

    void OnMouseDown()
    {
        errorImage.SetActive(true);
        Invoke(nameof(HideImage), 2.0f);
    }

    void HideImage()
    {
        errorImage.SetActive(false);
    }
}