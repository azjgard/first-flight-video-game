using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public void loadMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
