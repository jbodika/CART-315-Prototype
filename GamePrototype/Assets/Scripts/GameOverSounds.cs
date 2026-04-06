using UnityEngine;

public class GameOverSounds : MonoBehaviour
{

    public AudioSource sirens, storm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindObjectOfType<SecurityOfficer>().enabled = false;
        
    sirens.Play();
    storm.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
