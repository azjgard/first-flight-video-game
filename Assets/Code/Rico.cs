using UnityEngine;
using UnityEngine.SceneManagement;

public class Rico : MonoBehaviour
{
  public void throwPigSkin()
  {
    SceneManager.LoadScene("GameOver");
  }
}
