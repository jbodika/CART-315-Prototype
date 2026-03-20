using UnityEngine;
using UnityEngine.SceneManagement;

public class SecurityOfficer : MonoBehaviour
{
    public GameObject hidingScreen;
    public AudioSource footsteps;
    public AudioSource doorOpen;
    public AudioSource doorClose; 
	public AudioSource storm;

    private float stepsTimer;
    private float doorTimer;
    private float afterDoorCloseTimer;
    private float delayTimer;
    private bool WalkingInEvent = false;
    private bool WalkingOutEventDone = false;
    private bool WalkingInEventStarted = false;
    private bool delayTimerStarted = false;
    private bool hiding = false;
    
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        hidingScreen.SetActive(false);
        StartPatrol();
		storm.Play();
    }

    void StartPatrol()
    {
        footsteps.time = Random.Range(0f, footsteps.clip.length);
        footsteps.Play(); 
        
        stepsTimer = Random.Range(12f, 18f);
        
    }
    
    void Update()
    {
        if (WalkingInEvent)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                hiding = true;
                hidingScreen.SetActive(true);
            }
            
            if (Input.GetKeyUp(KeyCode.H))
            {
                hiding = false;
                hidingScreen.SetActive(false);
                if (WalkingInEventStarted || WalkingOutEventDone)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        if (delayTimerStarted)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                delayTimerStarted = false;
                Debug.Log("Grace period ended, hiding = " + hiding);
                if (!hiding)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        if (WalkingInEventStarted)
        {
            doorTimer -= Time.deltaTime;
            if (doorTimer <= 0)
            {
                WalkingInEventStarted = false;
                doorClose.Play();
                afterDoorCloseTimer = 3f;
                WalkingOutEventDone = true;
            }
        }
        if (WalkingOutEventDone)
        {
            afterDoorCloseTimer -= Time.deltaTime;
            if (afterDoorCloseTimer <= 0)
            {
                WalkingOutEventDone = false;
                WalkingInEvent = false;
                hidingScreen.SetActive(false);
                StartPatrol();
            }
        }
        if (WalkingInEvent) return;
        
        stepsTimer -= Time.deltaTime;

        if (stepsTimer <= 0)
        {
            WalkingInEvent = true;
            footsteps.Stop();
            WalkingIn();
        }
        
    }
    void WalkingIn()
    {
        Debug.Log("WalkingIn called");
        Debug.Log(doorOpen.clip);
        doorOpen.Play();
        doorTimer = 7f;
        WalkingInEventStarted = true;
        delayTimer = 2f;
        delayTimerStarted = true;

    }
    
}
