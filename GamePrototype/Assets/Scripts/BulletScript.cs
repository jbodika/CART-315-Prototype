using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioSource scoreSound, blip;

void Start() {
scoreSound.volume = 0.1f;
blip.volume = 0.1f;
}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
    {
            Destroy(gameObject);
        }
        // did we hit a Brick
        if (other.gameObject.tag == "Brick")
        {
            int r = Random.Range(10, 20);
            //GameManager.S.lives -= 1;
            GameManager.S.AddPoint(r);

            Destroy(other.gameObject);
            Destroy(gameObject);


        }
    }
}
