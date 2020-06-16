using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void play()
  {
    SceneManager.LoadScene("Playing");
  }

  public void quit()
  {
    UnityEditor.EditorApplication.isPlaying = false;
    Application.Quit();
  }
}
