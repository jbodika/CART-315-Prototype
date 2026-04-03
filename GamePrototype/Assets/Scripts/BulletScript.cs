using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    public AudioSource scoreSound, blip, dead;
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            blip.Play();
        }
        // did we hit a Brick
        if (other.gameObject.tag == "Brick")
        {
            scoreSound.Play();
            int r = Random.Range(10, 20);
            //GameManager.S.lives -= 1;
            GameManager.S.AddPoint(r);

            Destroy(other.gameObject);
            Destroy(gameObject);


        }
    }
}
