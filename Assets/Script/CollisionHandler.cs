using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
     [SerializeField] float levelgecikmezamani = 2f;
     [SerializeField] AudioClip carpmasesi;
     [SerializeField] AudioClip finishsesi;
     AudioSource audioSource;
     [SerializeField] ParticleSystem carpmaefekti;
     [SerializeField] ParticleSystem finishefekti;
     bool isTransitioning;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();   
    }

    void Update()
    {
       nextLevel();
    }


    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
            {
            case "Friendly":
                Debug.Log("Burada Güvendesiniz.");
                break;
            case "Finish":
                Debug.Log("Tebrikler Bitirdinizzz.");
                NextLevelScene();
                break;
            case "fuel":
                Debug.Log("Yakıt Aldınız.");
                break;
            default:
                Debug.Log("Üzgünüm Patladın.");
                StartCrashSequence();
                break;
            }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    void LoadNextLevel()
    {
        int levelindeksi = SceneManager.GetActiveScene().buildIndex;
        int yenilevelindeksi = levelindeksi + 1;
        if (yenilevelindeksi == SceneManager.sceneCountInBuildSettings)
        {
            yenilevelindeksi = 0;
        }
        SceneManager.LoadScene(yenilevelindeksi);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(carpmasesi);
        carpmaefekti.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelgecikmezamani);
    }
    void NextLevelScene()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishsesi);
        finishefekti.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelgecikmezamani);
        
    }

    void nextLevel()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
    }

    void collisionexit()
    {
        if (Input.GetKey(KeyCode.C))
        {
            
        }
    }
    
}