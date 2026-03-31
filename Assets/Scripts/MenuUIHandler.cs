using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    /// <summary>
    /// Load the main scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Exit the game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
        // If running in editor, exit playmode
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
