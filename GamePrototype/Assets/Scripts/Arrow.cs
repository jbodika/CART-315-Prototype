using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject monitorBack;
    public GameObject monitorFront;

    private bool isFrontActive = false;

    void Start()
    {
        monitorFront.SetActive(false);
        monitorBack.SetActive(true);


    }

    void OnMouseDown()
    {
         isFrontActive = !isFrontActive;
        monitorBack.SetActive(!isFrontActive);
        monitorFront.SetActive(isFrontActive);
      

        Debug.Log("Arrow Clicked");




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
