using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject[] puzzleObjects; 
    public GameObject errorMessage;    
    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    private AudioSource sound;
    public GameObject[] hiddenDecorativeAssets;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        // Hide cables at start
        foreach (GameObject obj in puzzleObjects)
            obj.SetActive(false);

        if (errorMessage != null)
            errorMessage.SetActive(false);
    }

    void OnMouseDown()
    {
       
        // Box clicked before monitor
        if (!Monitor.isActivated)
        {
            Debug.Log("Clicked");
            if (errorMessage != null)
                StartCoroutine(ShowError());
            return;
           
        
        }

        // Monitor was clicked first 
        if (!isOpen)
        { isOpen = true;
            spriteRenderer.sprite = openImage;
            sound.Play();

            StartCoroutine(DisplayAndHideAssets());
       

        }
    }

    private IEnumerator ShowError()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        errorMessage.SetActive(false);
    }
    IEnumerator DisplayAndHideAssets()
    {
        yield return new WaitForSeconds(2f);

        foreach (GameObject obj in hiddenDecorativeAssets)
            obj.SetActive(false);


        foreach (GameObject obj in puzzleObjects)
            obj.SetActive(true);
    }

}