using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;
    private Vector3 startPosition;
    private Sprite originalSprite;
    private Socket currentSocket;
    public string correctSocket;
    public string connectedSocket;

    public Sprite pickedUpImage;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        originalSprite = spriteRenderer.sprite;
    }

    void OnMouseDown()
    {
        dragging = true;
        spriteRenderer.sprite = pickedUpImage;

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }
    }

    void OnMouseUp()
    {
        dragging = false;

        if (currentSocket != null && !currentSocket.occupied)
        {
            transform.position = currentSocket.transform.position;

            connectedSocket = currentSocket.name;

            currentSocket.occupied = true;

            enabled = false;

            FindObjectOfType<PuzzleManager>().CableConnected();
        }
    }

    public void ResetCable()
    {
        transform.position = startPosition;

        connectedSocket = null;

        spriteRenderer.sprite = originalSprite;

        enabled = true; // allow dragging again
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Socket"))
        {
            currentSocket = other.GetComponent<Socket>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Socket"))
        {
            currentSocket = null;
        }
    }

}