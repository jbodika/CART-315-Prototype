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
        ChangeImage();
    }

    void OnMouseDown()
    {

        isActivated = true;
        gameObject.SetActive(false);
        arrow.SetActive(false);

    }


    void ChangeImage()
    {
        if (PuzzleManager.isMiniPuzzleOneComplete)
        {
           spriteRenderer.sprite = completedImage;
            isActivated = false;

        }


    }


}
