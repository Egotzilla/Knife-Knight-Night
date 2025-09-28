using UnityEngine;

public class EscapeKeyTester : MonoBehaviour
{
    private void Update()
    {
        // Simple test to see if escape key is detected
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key detected with legacy input system!");
        }
    }
}