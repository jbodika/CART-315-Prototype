using UnityEngine;
using UnityEngine.SceneManagement;


public class FrontMonitor : MonoBehaviour
{
    public GameObject errorImage;

    void Awake()
    {
        errorImage.SetActive(false); // hide at start
    }

    void OnMouseDown()
    {

        if (PuzzleManager.isMiniPuzzleOneComplete)
        {
            Debug.Log("MINI GAME 2");
            SceneManager.LoadScene("MiniGame2");
            return;
        }
        else
        {
            errorImage.SetActive(true);
            Invoke(nameof(HideImage), 2.0f);

        }
    }

    void HideImage()
    {
        errorImage.SetActive(false);
    }
}