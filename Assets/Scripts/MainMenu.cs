using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    
    [Header("Scene Settings")]
    [SerializeField] private string gameplaySceneName = "Sandbox_v2";
    
    private void Start()
    {
        // Set up button listeners
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }
    
    private void OnDestroy()
    {
        // Clean up listeners
        if (startButton != null)
        {
            startButton.onClick.RemoveListener(StartGame);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.RemoveListener(ExitGame);
        }
    }
    
    public void StartGame()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene(gameplaySceneName);
    }
    
    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}