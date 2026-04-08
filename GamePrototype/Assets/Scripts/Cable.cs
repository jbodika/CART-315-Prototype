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
    public Transform snapPoint;
    public Sprite pickedUpImage;
    private SpriteRenderer spriteRenderer;
   // public GameObject[] decorativeAssets;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        originalSprite = spriteRenderer.sprite;
    }

    void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteRenderer.sprite = pickedUpImage;
        if (!string.IsNullOrEmpty(connectedSocket))
        {
            foreach (Socket s in FindObjectsOfType<Socket>())
            {
                if (s.name == connectedSocket)
                {
                    s.occupied = false;
                    break;
                }
            }
            connectedSocket = null;
        }
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
        else
        {
            // Reverts the sprite to original
            spriteRenderer.sprite = originalSprite;
        }
    }
    public void ResetCable()
    {
        // Gets the cable that the socket was connected to and resets it
        if (!string.IsNullOrEmpty(connectedSocket))
        {
            foreach (Socket s in FindObjectsOfType<Socket>())
            {
                if (s.name == connectedSocket)
                {
                    s.occupied = false;
                    break;
                }
            }
        }

        transform.position = startPosition;
        connectedSocket = null;
        spriteRenderer.sprite = originalSprite;
        enabled = true;
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