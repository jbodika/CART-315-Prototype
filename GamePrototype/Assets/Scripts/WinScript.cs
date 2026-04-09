using UnityEngine;

public class WinScript : MonoBehaviour
{

    public AudioSource Hooray;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		SecurityOfficer officer = FindFirstObjectByType<SecurityOfficer>();
        if (officer != null) Destroy(officer.gameObject);

        Hooray.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
