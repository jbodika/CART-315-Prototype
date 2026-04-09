using UnityEngine;

public class WinScript : MonoBehaviour
{

    public AudioSource Hooray;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindObjectOfType<SecurityOfficer>().enabled = false;

        Hooray.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
