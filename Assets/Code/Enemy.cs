using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  private WaveManager waveManager;

  public GameObject alive;
  public GameObject dead;

  void Awake()
  {
    GameObject waveManagerObject = GameObject.Find("WaveManager");
    this.waveManager = (WaveManager)waveManagerObject.GetComponent(typeof(WaveManager));
  }

  void OnMouseDown()
  {
    if (this.alive.activeSelf == false)
    {
      return;
    }

    this.alive.SetActive(false);
    this.dead.SetActive(true);

    StartCoroutine("Die");
  }

  private IEnumerator Die()
  {
    for (float ft = 1f; ft >= 0; ft -= 0.1f)
    {
      Renderer[] renderers = this.dead.GetComponentsInChildren<Renderer>();

      foreach (Renderer r in renderers)
      {
        Color c = r.material.color;
        c.a = ft;
        r.material.color = c;
      }

      yield return new WaitForSeconds(.05f);
    }

    Destroy(this.gameObject);
    this.waveManager.enemyKilled(this.gameObject);

    yield return null;
  }
}
