using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;

    void Start()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
    }

    void OnMouseDown()
    {
        Debug.Log("Monitor Clicked");

        // destroy monitor
        Destroy(gameObject);

        // show the new images
        image1.SetActive(true);
        image2.SetActive(true);
        image3.SetActive(true);
        image4.SetActive(true);
    }


    // click on monitor function 


    // click on cable box-- for next week 

    // open cable box- for next week

    // grab and place cables - done throught the cable.cs file

    // error check 


}
