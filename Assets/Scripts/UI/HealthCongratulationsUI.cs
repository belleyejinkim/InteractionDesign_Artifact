using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays a congratulations UI (image and text) when artifact health reaches 90 from below
/// </summary>
public class HealthCongratulationsUI : MonoBehaviour
{
    [SerializeField] Artifact artifact;
    [SerializeField] Image congratulationsImage;
    [SerializeField] Text congratulationsText;
    
    [SerializeField] int congratulationsHealthThreshold = 90;
    [SerializeField] float displayDuration = 2f;
    
    bool congratulationsShown = false;
    int previousHealth = -1;
    Coroutine hideCoroutine;
    
    void Start()
    {
        // Start with UI hidden
        if (congratulationsImage != null)
            congratulationsImage.gameObject.SetActive(false);
        if (congratulationsText != null)
            congratulationsText.gameObject.SetActive(false);
        
        // Initialize previous health
        if (artifact != null)
        {
            previousHealth = artifact.health;
        }
    }
    
    void Update()
    {
        if (artifact == null)
            return;
        
        int currentHealth = artifact.health;
        
        // Check if health reached the threshold from below (health increased)
        // previousHealth < threshold AND currentHealth >= threshold
        if (!congratulationsShown && 
            previousHealth < congratulationsHealthThreshold && 
            currentHealth >= congratulationsHealthThreshold)
        {
            ShowCongratulations();
        }
        
        // Update previous health for next frame
        previousHealth = currentHealth;
    }
    
    void ShowCongratulations()
    {
        congratulationsShown = true;
        
        // Show the UI elements
        if (congratulationsImage != null)
            congratulationsImage.gameObject.SetActive(true);
        if (congratulationsText != null)
        {
            congratulationsText.gameObject.SetActive(true);
            congratulationsText.text = "잘했다";
        }
        
        // Hide after displayDuration seconds
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(HideAfterDelay());
    }
    
    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        
        // Hide the UI elements
        if (congratulationsImage != null)
            congratulationsImage.gameObject.SetActive(false);
        if (congratulationsText != null)
            congratulationsText.gameObject.SetActive(false);
    }
    
    // Method to reset congratulations (in case you want to show it again)
    public void ResetCongratulations()
    {
        congratulationsShown = false;
        if (artifact != null)
        {
            previousHealth = artifact.health;
        }
    }
}
