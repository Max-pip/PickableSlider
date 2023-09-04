using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        string currentName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentName);
    }
}
