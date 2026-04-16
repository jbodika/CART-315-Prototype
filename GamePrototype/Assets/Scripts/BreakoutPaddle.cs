using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddle : MonoBehaviour {
    private float     xPos;
    public float      paddleSpeed = .05f;
    public float      leftWall, rightWall;

    public KeyCode leftKey, rightKey;

    // Start is called before the first frame update
    void Start() {


    }

    void Update()
    {
        if (Time.timeScale == 0) return; // paused while hiding

        if (Input.GetKey(leftKey))
        {
            if (xPos > leftWall) xPos -= paddleSpeed;
        }
        if (Input.GetKey(rightKey))
        {
            if (xPos < rightWall) xPos += paddleSpeed;
        }
        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
    }
}

