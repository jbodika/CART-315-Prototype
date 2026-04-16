using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SecurityOfficer : MonoBehaviour
{
    public static SecurityOfficer instance;
    public GameObject hidingScreen;
    public AudioSource footsteps;
    public AudioSource doorOpen;
    public AudioSource doorClose; 
	public AudioSource storm;
	public GameObject hideMessage;

    private float stepsTimer;
    private float doorTimer;
    private float afterDoorCloseTimer;
    private float graceTimer;

    private bool WalkingInEvent = false;
    private bool WalkingOutEventDone = false;
    private bool WalkingInEventStarted = false;
    private bool gracePeriodActive = false;

    private bool isTransitioning = false;
    private bool isFirstLoad = true;

    void HideMessage() { 
    hideMessage.SetActive(false);
}
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isTransitioning = false;

        WalkingInEvent = false;
        WalkingOutEventDone = false;
        WalkingInEventStarted = false;
        gracePeriodActive = false;
        doorOpen.Stop();
        doorClose.Stop();

        if (!isFirstLoad)
        {
            StartPatrol(); // called after the first load has started
        }
    }

    void Start()
    {
        isFirstLoad = false; // set the first load to false
        hidingScreen.SetActive(false);
        storm.Play();
        hideMessage.SetActive(true);
        Invoke(nameof(HideMessage), 3.0f);

        // starts footsteps but with a long initial timer
        footsteps.time = Random.Range(0f, footsteps.clip.length);
        footsteps.Play();
        stepsTimer = Random.Range(20f, 30f);
    }

    void StartPatrol()
    {
        footsteps.time = Random.Range(0f, footsteps.clip.length);
        footsteps.Play();
        stepsTimer = Random.Range(12f, 18f);
    }
    public void PauseForTransition()
    {
        isTransitioning = true;
        WalkingInEvent = false;
        WalkingInEventStarted = false;
        gracePeriodActive = false;
        doorOpen.Stop();
        footsteps.Stop();
    }


    void Update()
    {
        if (isTransitioning) return;
        Time.timeScale = Input.GetKey(KeyCode.H) ? 0f : 1f;
        hidingScreen.SetActive(Input.GetKey(KeyCode.H));

        if (gracePeriodActive)
        {
            graceTimer -= Time.unscaledDeltaTime; 
            if (graceTimer <= 0)
            {
                gracePeriodActive = false;
                if (!Input.GetKey(KeyCode.H))
                {
                    SceneManager.LoadScene("GameOver");
                    return;
                }
                WalkingInEventStarted = true;
            }
        }

        if (WalkingInEventStarted)
        {
            doorTimer -= Time.unscaledDeltaTime; 
            if (!Input.GetKey(KeyCode.H))
            {
                SceneManager.LoadScene("GameOver");
                return;
            }
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
            afterDoorCloseTimer -= Time.unscaledDeltaTime; 
            if (afterDoorCloseTimer <= 0)
            {
                WalkingOutEventDone = false;
                WalkingInEvent = false;
                StartPatrol();
            }
        }

        if (WalkingInEvent) return;

        stepsTimer -= Time.unscaledDeltaTime; 
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
  
        graceTimer = 2f;
        gracePeriodActive = true;

    }
    
}