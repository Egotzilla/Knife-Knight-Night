using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseHandler : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject winLoseCanvas;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    
    [Header("Buttons (shared for both win and lose)")]
    [SerializeField] private Button homeButton;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button exitButton;
    
    [Header("Scene Settings")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string gameplaySceneName = "Sandbox_v2";
    
    [Header("Game References")]
    [SerializeField] private PlayerStateMachine playerStateMachine;
    
    private bool gameEnded = false;
    private bool playerIsDead = false;
    
    void Start()
    {
        // Hide win/lose canvas initially
        if (winLoseCanvas != null) winLoseCanvas.SetActive(false);
        
        // Hide both panels initially
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        
        // Set up button listeners
        SetupButtonListeners();
        
        // Find player if not assigned
        if (playerStateMachine == null)
        {
            playerStateMachine = FindObjectOfType<PlayerStateMachine>();
        }
        
        // Subscribe to player death event
        if (playerStateMachine != null && playerStateMachine.Health != null)
        {
            playerStateMachine.Health.OnDie += HandlePlayerDeath;
        }
    }
    
    void Update()
    {
        if (!gameEnded)
        {
            CheckWinCondition();
        }
    }
    
    private void CheckWinCondition()
    {
        // Check if player collected 10 lanterns and is not dead
        if (lanternCount.Instance != null)
        {
            int currentLanterns = lanternCount.Instance.GetLanternCount();
            
            if (currentLanterns >= 10 && !playerIsDead)
            {
                ShowWinScreen();
            }
        }
    }
    
    private void HandlePlayerDeath()
    {
        playerIsDead = true;
        ShowLoseScreen();
    }
    
    private void ShowWinScreen()
    {
        if (gameEnded) return;
        
        gameEnded = true;
        
        Debug.Log("Player Won! Showing win screen...");
        
        // Show the main canvas
        if (winLoseCanvas != null)
        {
            winLoseCanvas.SetActive(true);
        }
        
        // Show win panel, hide lose panel
        if (winPanel != null) winPanel.SetActive(true);
        if (losePanel != null) losePanel.SetActive(false);
        
        // Pause the game
        Time.timeScale = 0f;
        
        // Show cursor and ensure it's not locked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Debug.Log("Win screen displayed!");
    }
    
    private void ShowLoseScreen()
    {
        if (gameEnded) return;
        
        gameEnded = true;
        
        Debug.Log("Player Lost! Showing lose screen...");
        
        // Show the main canvas
        if (winLoseCanvas != null)
        {
            winLoseCanvas.SetActive(true);
        }
        
        // Show lose panel, hide win panel
        if (losePanel != null) losePanel.SetActive(true);
        if (winPanel != null) winPanel.SetActive(false);
        
        // Pause the game
        Time.timeScale = 0f;
        
        // Show cursor and ensure it's not locked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Debug.Log("Lose screen displayed!");
    }
    
    private void SetupButtonListeners()
    {
        // Set up the 3 shared buttons
        if (homeButton != null)
        {
            homeButton.onClick.AddListener(GoToMainMenu);
            Debug.Log("Home button listener added");
        }
        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(PlayAgain);
            Debug.Log("Play Again button listener added");
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
            Debug.Log("Exit button listener added");
        }
    }
    
    public void GoToMainMenu()
    {
        Debug.Log("GoToMainMenu button clicked!");
        
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reset lantern count
        if (lanternCount.Instance != null)
        {
            lanternCount.Instance.ResetLanternCount();
        }
        
        // Load main menu scene
        SceneManager.LoadScene(mainMenuSceneName);
    }
    
    public void PlayAgain()
    {
        Debug.Log("PlayAgain button clicked!");
        
        // Reset time scale
        Time.timeScale = 1f;
        
        // Reset lantern count
        if (lanternCount.Instance != null)
        {
            lanternCount.Instance.ResetLanternCount();
        }
        
        // Reload current scene
        SceneManager.LoadScene(gameplaySceneName);
    }
    
    public void ExitGame()
    {
        Debug.Log("ExitGame button clicked!");
        
        // Reset time scale before quitting
        Time.timeScale = 1f;
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    // Public methods to manually trigger win/lose for testing
    public void TriggerWin()
    {
        ShowWinScreen();
    }
    
    public void TriggerLose()
    {
        ShowLoseScreen();
    }
    
    private void OnDestroy()
    {
        // Clean up event subscriptions
        if (playerStateMachine != null && playerStateMachine.Health != null)
        {
            playerStateMachine.Health.OnDie -= HandlePlayerDeath;
        }
        
        // Clean up button listeners
        if (homeButton != null)
            homeButton.onClick.RemoveListener(GoToMainMenu);
        if (playAgainButton != null)
            playAgainButton.onClick.RemoveListener(PlayAgain);
        if (exitButton != null)
            exitButton.onClick.RemoveListener(ExitGame);
    }
}
