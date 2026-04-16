using UnityEngine;

public class ShootingPaddle : MonoBehaviour {
    public GameObject shot;
    public float shotSpeed = 10;
    public KeyCode fireButton;
    public GameObject shotLocation;

    public bool Shoot = false;
    public AudioSource  scoreSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        scoreSound.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return; // paused while hiding

        if (Shoot && Input.GetKeyDown(fireButton))
        {
            Fire();
        }
    }


    public void Fire() {
        scoreSound.Play();
        
        GameObject go = Instantiate<GameObject>(shot);
        go.transform.position = shotLocation.transform.position + new Vector3(0, 0.5f, 0);
        
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.linearVelocityY = shotSpeed;
    }
}
