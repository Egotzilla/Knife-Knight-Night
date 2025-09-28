using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lanternHandler : MonoBehaviour
{
    [Header("Lantern Objects")]
    [SerializeField] private GameObject lanternOn;  // The visible/lit lantern
    [SerializeField] private GameObject lanternOff; // The invisible/unlit lantern
    
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask playerLayer = -1;
    
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI interactionText;
    
    private bool isLanternOn = false; // Track current lantern state - start with off
    private Transform playerTransform;
    private InputReader inputReader;
    private bool wasInRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the player in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            
            // Get the InputReader component from the player
            inputReader = player.GetComponent<InputReader>();
            if (inputReader != null)
            {
                inputReader.ELightEvent += OnELightPressed;
            }
        }
        
        // Initialize lantern state - start with lantern off
        if (lanternOn != null) lanternOn.SetActive(false);
        if (lanternOff != null) lanternOff.SetActive(true);
        
        // Hide interaction text initially
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
{
    bool currentlyInRange = IsPlayerInRange();

    if (interactionText == null) return;

    if (currentlyInRange)
    {
        // ensure text GameObject is active
        if (!interactionText.gameObject.activeSelf) 
            interactionText.gameObject.SetActive(true);

        interactionText.text = isLanternOn ? "Lantern is already lit" : "Press E to light lantern";
    }
    else
    {
        if (interactionText.gameObject.activeSelf)
            interactionText.gameObject.SetActive(false);
    }

    wasInRange = currentlyInRange;
}


    
    private void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (inputReader != null)
        {
            inputReader.ELightEvent -= OnELightPressed;
        }
    }
    
    private void OnELightPressed()
    {
        // Check if player is in range when E is pressed
        // Only allow turning on if lantern is currently off
        if (playerTransform != null && IsPlayerInRange() && !isLanternOn)
        {
            TurnOnLantern();
        }
    }
    
    private bool IsPlayerInRange()
    {
        if (playerTransform == null) return false;
        
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance <= interactionRange;
    }
    
    private void TurnOnLantern()
    {
        // Only turn on if it's currently off
        if (!isLanternOn)
        {
            isLanternOn = true;
            
            // Turn lantern on - make it visible
            if (lanternOn != null) lanternOn.SetActive(true);
            if (lanternOff != null) lanternOff.SetActive(false);
            
            // Notify the lantern counter
            if (lanternCount.Instance != null)
            {
                lanternCount.Instance.IncrementLanternCount();
            }
            
            // Update text to show "already lit" if player still in range
            if (interactionText != null && wasInRange)
            {
                interactionText.text = "Lantern is already lit";
            }
            
            Debug.Log("Lantern turned on! It cannot be turned off again.");
        }else
        {
            // If lantern is already on, just update the text if player is in range
            if (interactionText != null && wasInRange)
            {
                interactionText.text = "Press E to light lantern";
            }
        }
    }
    
    // Draw interaction range in scene view for debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
