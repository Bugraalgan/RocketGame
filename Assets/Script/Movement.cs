using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField]  float hareketHizi = 100f;
    [SerializeField]  float dondurmeHizi= 100f;
    [SerializeField]  AudioClip mainengine;
    Rigidbody rb;
    AudioSource audioSource;
    bool isAlive;
    [SerializeField] ParticleSystem ucusefekti;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
      hareket();
      dondurme();
    }

    void hareket()
    {
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.up * (hareketHizi * Time.deltaTime));
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainengine);
            }
            if (!ucusefekti.isPlaying) // Uçuş efekti başlatılıyor
            {
                ucusefekti.Play();
            }
        }
        else
        {
            audioSource.Stop();
            if (ucusefekti.isPlaying) // Uçuş efekti durduruluyor
            {
                ucusefekti.Stop();
            }
        }
    }
    

    void dondurme()
    {
        if (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.LeftArrow))
        {
            newMethod(dondurmeHizi);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newMethod(-dondurmeHizi);
        }
    }
    void newMethod(float rotationSpeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward*(rotationSpeed * Time.deltaTime));
        unfreeze();
        
    }

    void unfreeze()
    {
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}

