using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneSwitcher : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void LoadScene(string sceneName)
    {
        // Make sure the scene is added to Build Settings
        SceneManager.LoadScene(sceneName);
    }
}
