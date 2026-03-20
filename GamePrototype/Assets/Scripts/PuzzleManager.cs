using UnityEngine;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public Cable[] cables;
    public Socket[] sockets;

    public AudioSource soundCorrect;
    public AudioSource soundWrong;
    public GameObject checkmarkImage;
    public GameObject xImage;

    public static bool isMiniPuzzleOneComplete;

    private int connectedCables = 0;

    void Start()
    {
        checkmarkImage.SetActive(false);
        xImage.SetActive(false);
    }

    public void CableConnected()
    {
        connectedCables++;

        if (connectedCables == cables.Length)
        {
            CheckPuzzle();
        }
    }

    void CheckPuzzle()
    {
        bool allCorrect = true;

        foreach (Cable c in cables)
        {
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
        }
        else
        {
            xImage.SetActive(true);
            StartCoroutine(ResetPuzzle()); // 
            soundWrong.Play();
        }
    }

    IEnumerator ResetPuzzle()
    {
        yield return new WaitForSeconds(2f); // wait 2 seconds

        xImage.SetActive(false);

        // reset cables
        foreach (Cable c in cables)
        {
            c.ResetCable();
        }

        // reset sockets
        foreach (Socket s in sockets)
        {
            s.occupied = false;
        }

        connectedCables = 0;
    }
}