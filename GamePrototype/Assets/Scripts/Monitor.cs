using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor : MonoBehaviour
{
    //public GameObject image1;
    //public GameObject image2;
    //public GameObject image3;
    //public GameObject image4;
    public GameObject arrow;
    public static bool isActivated = false;
    private SpriteRenderer spriteRenderer;
  //  private Sprite originalSprite;
    public Sprite completedImage;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        isActivated = false;
       // originalSprite = spriteRenderer.sprite;
        ChangeImage();
        //image1.SetActive(false);
        //image2.SetActive(false);
        //image3.SetActive(false);
        //image4.SetActive(false);
    }

    void OnMouseDown()
    {
        Debug.Log("Monitor Clicked");
        Debug.Log("Are you even workingggg ");

        isActivated = true;
        //hide monitor
        // Destroy(gameObject);
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
        arrow.SetActive(false);
        // show the new images
        //image1.SetActive(true);
        //image2.SetActive(true);
        //image3.SetActive(true);
        //image4.SetActive(true);
    }


    void ChangeImage()
    {
        if (PuzzleManager.isMiniPuzzleOneComplete)
        {
           spriteRenderer.sprite = completedImage;
            isActivated = false;

        }


    }

    // click on monitor function 


    // click on cable box-- for next week 

    // open cable box- for next week

    // grab and place cables - done throught the cable.cs file

    // error check 


}
