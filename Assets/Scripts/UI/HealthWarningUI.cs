using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays a warning UI (image and text) when artifact health reaches 30
/// </summary>
public class HealthWarningUI : MonoBehaviour
{
    [SerializeField] Artifact artifact;
    [SerializeField] Image warningImage;
    [SerializeField] Text warningText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip warningClip;
    [SerializeField, Range(0f, 2f)] float warningVolume = 1f;
    
    [SerializeField] int warningHealthThreshold = 30;
    [SerializeField] float displayDuration = 2f;
    
    bool warningShown = false;
    Coroutine hideCoroutine;
    
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.loop = false;
                audioSource.spatialBlend = 0f; // force 2D so it is always audible
            audioSource.volume = warningVolume;
            }
        else
        {
            audioSource.volume = warningVolume;
        }
        }
        
        // Start with UI hidden
        if (warningImage != null)
            warningImage.gameObject.SetActive(false);
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
    
    void Update()
    {
        // Check if health reached the threshold and warning hasn't been shown yet
        if (!warningShown && artifact != null && artifact.health <= warningHealthThreshold)
        {
            ShowWarning();
        }
    }
    
    void ShowWarning()
    {
        warningShown = true;
        
        // Show the UI elements
        if (warningImage != null)
            warningImage.gameObject.SetActive(true);
        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);
            warningText.text = "열심히 해보세요";
        }
        
        PlayWarningSound();
        
        // Hide after displayDuration seconds
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(HideAfterDelay());
    }
    
    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        
        // Hide the UI elements
        if (warningImage != null)
            warningImage.gameObject.SetActive(false);
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
    
    // Method to reset warning (in case you want to show it again)
    public void ResetWarning()
    {
        warningShown = false;
    }
    
    void PlayWarningSound()
    {
        if (warningClip == null)
            return;
        
        if (audioSource != null)
        {
            audioSource.PlayOneShot(warningClip, warningVolume);
            return;
        }
        
        AudioSource.PlayClipAtPoint(warningClip, transform.position);
    }
}
