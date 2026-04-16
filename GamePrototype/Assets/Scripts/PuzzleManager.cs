using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PuzzleManager : MonoBehaviour
{
    public Cable[] cables;
    public AudioSource soundCorrect;
    public AudioSource soundWrong;
    public GameObject checkmarkImage;
    public GameObject xImage;
    public static bool isMiniPuzzleOneComplete;


    void Start()
    {
        checkmarkImage.SetActive(false);
        xImage.SetActive(false);
      
    }

    public void CableConnected()
    {
        // counts how many cables are currently connected
        int connectedCount = 0;
        foreach (Cable c in cables)
        {
            if (!string.IsNullOrEmpty(c.connectedSocket))
                connectedCount++;
        }

        //checks if all cables are connected
        if (connectedCount == cables.Length)
        {
            CheckPuzzle();
        }
    }

    void CheckPuzzle()
    {
        bool allCorrect = true;

        foreach (Cable c in cables)
        {
            Debug.Log(c);
            if (c.connectedSocket != c.correctSocket)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            checkmarkImage.SetActive(true);
            isMiniPuzzleOneComplete = true;
            soundCorrect.Play();

            StartCoroutine(SwitchScenes());
        }
        else
        {
            xImage.SetActive(true);
            soundWrong.Play();
            StartCoroutine(ResetPuzzle());
        }
    }

    IEnumerator SwitchScenes()
    {
        // prevents the security guard from interrupting during the transition
        if (SecurityOfficer.instance != null)
            SecurityOfficer.instance.PauseForTransition();

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TransitionToGame2");
    }

    IEnumerator ResetPuzzle()
    {
        yield return new WaitForSeconds(2f);
        xImage.SetActive(false);

        foreach (Cable c in cables)
            c.ResetCable(); // resets the cables and sockets

        isMiniPuzzleOneComplete = false;
    }

  
}