using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lanternCount : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI lanternCountText;
    [SerializeField] private GameObject lanternCountPanel;
    
    [Header("Settings")]
    [SerializeField] private string displayFormat = "Lanterns: {0} / 10";
    
    private static lanternCount instance;
    private int currentLanternCount = 0;
    
    public static lanternCount Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<lanternCount>();
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start()
    {
        Debug.Log("LanternCount Start() called");
        Debug.Log($"Initial display format: '{displayFormat}'");
        UpdateUI();
    }
    
    public void IncrementLanternCount()
    {
        currentLanternCount++;
        UpdateUI();
        Debug.Log($"Lantern count increased to: {currentLanternCount}");
    }
    
    public int GetLanternCount()
    {
        return currentLanternCount;
    }
    
    public void ResetLanternCount()
    {
        currentLanternCount = 0;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        Debug.Log("UpdateUI() called");
        
        if (lanternCountText != null)
        {
            // Force the format string to be exactly what we want
            string targetText = $"Lanterns: {currentLanternCount} / 10";
            lanternCountText.text = targetText;
            
            Debug.Log($"Display format: '{displayFormat}'");
            Debug.Log($"Target text: '{targetText}'");
            Debug.Log($"Text component text: '{lanternCountText.text}'");
            Debug.Log($"Text component enabled: {lanternCountText.enabled}");
            Debug.Log($"Text component gameObject active: {lanternCountText.gameObject.activeSelf}");
        }
        else
        {
            Debug.LogWarning("LanternCountText is not assigned!");
        }
        
        // Show/hide the panel based on whether any lanterns have been lit
        if (lanternCountPanel != null)
        {
            lanternCountPanel.SetActive(currentLanternCount > 0);
            Debug.Log($"Panel active: {lanternCountPanel.activeSelf}");
        }
        else
        {
            Debug.LogWarning("LanternCountPanel is not assigned!");
        }
    }
}
