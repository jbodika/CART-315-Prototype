using UnityEngine;

public class SoundsGameOver : MonoBehaviour
{

    public AudioSource thunder;
    public AudioSource sirens;

    
    void Awake()
    {
        SecurityOfficer officer = FindFirstObjectByType<SecurityOfficer>();
        if (officer != null) Destroy(officer.gameObject);
    }
    
    void Start()
    {
        thunder.Play();
        sirens.Play();

    }

    void Update()
    {
        
    }
}
