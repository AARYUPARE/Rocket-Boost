using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class ColllisionHandller : MonoBehaviour
{
    int CurrentScene;
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip SuccessAudio;
    [SerializeField] AudioClip CrashAudio;
    [SerializeField] ParticleSystem SuccessParticles;
    [SerializeField] ParticleSystem CrashParticles;
 
    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;
    

    private void OnEnable()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        RespondToDebugKeys();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !isCollidable)
        {
            return;
        }
            switch (collision.gameObject.tag)
            {
                case "Fule":
                    Debug.Log("You got some fule");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    break;
                case "Friendly":
                    Debug.Log("Let's start!");
                    Debug.Log("Press 'Space' To Fly \n 'Right Arrow' To Turn right \n 'Left Arrow' To Turn Left");
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        

    }

    private void StartSuccessSequence()
    {
        isControllable = GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(SuccessAudio, 0.7f);
        SuccessParticles.Play();
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
       
        isControllable = GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(CrashAudio, 0.3f);
        CrashParticles.Play(); 
        Invoke("ReloadLevel", delay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    void LoadNextLevel()
    {
        int NextScene = CurrentScene + 1;
        if (NextScene == SceneManager.sceneCountInBuildSettings)
        {
            NextScene = 0;
        }
        SceneManager.LoadScene(NextScene);
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }
}
