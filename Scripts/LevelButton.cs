using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
