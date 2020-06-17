using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public GameObject alive;
  public GameObject dead;

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

  IEnumerator Die()
  {
    for (float ft = 1f; ft >= 0; ft -= 0.1f)
    {
      var renderers = this.dead.GetComponentsInChildren<Renderer>();

      foreach (Renderer r in renderers)
      {
        Color c = r.material.color;
        c.a = ft;
        r.material.color = c;
      }

      yield return new WaitForSeconds(.05f);
    }

    Destroy(this.gameObject);

    yield return null;
  }
}
