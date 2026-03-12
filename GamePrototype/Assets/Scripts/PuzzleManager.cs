using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Cable[] cables;

    public GameObject checkmarkImage;
    public GameObject xImage;

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
        }
        else
        {
            xImage.SetActive(true);
        }
    }
}