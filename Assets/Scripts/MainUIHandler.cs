using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    /// <summary>
    /// Return to the main menu scene
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
