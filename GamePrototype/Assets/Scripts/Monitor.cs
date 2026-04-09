using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor : MonoBehaviour
{
    public GameObject arrow;
    public static bool isActivated = false;
    private SpriteRenderer spriteRenderer;
    public Sprite completedImage;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isActivated = false;
        if (PuzzleManager.isMiniPuzzleOneComplete)
        {
            spriteRenderer.sprite = completedImage;
            isActivated = false;
        }
    }

    void OnMouseDown()
    {

        if (SceneManager.GetSceneByName("MiniGame1").IsValid())
        {
            isActivated = true;
            gameObject.SetActive(false);
            arrow.SetActive(false); 
        }

      
    }



}
