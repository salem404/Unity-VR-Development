
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayAudioAttachment : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public float rotationSpeed = 30f; // Degrees per second
    
    private Transform attachedDisc;

    void Start()
    {
        if (socketInteractor == null)
        {
            return;
        }

        // Subscribe to select entered and exited events
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
        socketInteractor.selectExited.AddListener(OnSelectExited);
    }

    void Update()
    {
        // Rotate the socket (and attached disc) if there is a disc attached
        if (attachedDisc != null)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Get the audio source from the attached object
        AudioSource audioSource = args.interactableObject.transform.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        
        // Store reference to the attached disc for rotation
        attachedDisc = args.interactableObject.transform;
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        // Stop audio from the detached object
        AudioSource audioSource = args.interactableObject.transform.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        
        // Clear the reference when disc is removed
        attachedDisc = null;
    }
}