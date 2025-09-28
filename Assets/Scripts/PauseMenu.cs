using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button exitButton;
    
    [Header("Scene Settings")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    
    private void Start()
    {
        // Set up button listeners
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }
        
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }
    
    private void OnDestroy()
    {
        // Clean up listeners
        if (resumeButton != null)
        {
            resumeButton.onClick.RemoveListener(ResumeGame);
        }
        
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.RemoveListener(ExitGame);
        }
    }
    
    public void ResumeGame()
    {
        Debug.Log("Resume button clicked!");
        
        // Hide the pause menu and resume the game
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        
        // Hide cursor for gameplay
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void GoToMainMenu()
    {
        Debug.Log("Main Menu button clicked!");
        
        // Resume time before changing scenes
        Time.timeScale = 1f;
        
        // Show cursor for main menu
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        SceneManager.LoadScene(mainMenuSceneName);
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit button clicked! Quitting game...");
        
        // Resume time and show cursor before quitting
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        #if UNITY_EDITOR
            Debug.Log("Stopping play mode in Unity Editor...");
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Debug.Log("Calling Application.Quit()...");
            Application.Quit();
        #endif
    }
}