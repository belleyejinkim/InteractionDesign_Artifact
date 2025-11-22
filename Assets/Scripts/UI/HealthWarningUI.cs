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
    
    [SerializeField] int warningHealthThreshold = 30;
    [SerializeField] float displayDuration = 2f;
    
    bool warningShown = false;
    Coroutine hideCoroutine;
    
    void Start()
    {
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
}
