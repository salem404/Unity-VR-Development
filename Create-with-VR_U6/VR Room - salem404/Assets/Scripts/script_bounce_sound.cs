using UnityEngine;

public class script_bounce_sound : MonoBehaviour
{
    public AudioClip bounceSound; // Assign this in the Inspector
    private AudioSource audioSource;
    private Rigidbody rigitbody;

    void Start()
    {
        // Get or add an AudioSource component to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        rigitbody = GetComponent<Rigidbody>();
        if (rigitbody == null)
        {
            Debug.LogError("Rigidbody component is missing on this GameObject.");
        }
        
        // Set the bounce sound clip to the AudioSource
        audioSource.clip = bounceSound;
    }

    void OnCollisionEnter(Collision collision)
    {
         float speed = rigitbody.linearVelocity.magnitude;

        // Play the bounce sound when a collision occurs
        if (bounceSound != null)
        {
            audioSource.volume = Mathf.Clamp(speed / 10f, 0.1f, 1f); // Adjust volume based on speed
            audioSource.Play();
        }
    }
}