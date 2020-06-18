using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{

  public GameObject enemy;
  public GameObject waveText;

  private bool playing = false;
  private List<GameObject> enemyList = new List<GameObject>();
  private int currentWave = 0;
  private int currentWaveStartingEnemyCount = 10;

  public void enemyKilled(GameObject enemy)
  {
    if (this.enemyList.Contains(enemy))
    {
      this.enemyList.Remove(enemy);
    }
  }

  void Awake()
  {
    this.waveText.GetComponent<CanvasGroup>().alpha = 0;
    StartCoroutine("BeginNextWave");
  }

  private IEnumerator BeginNextWave()
  {
    this.currentWave++;
    this.currentWaveStartingEnemyCount = (int)Math.Ceiling((float)this.currentWave * 1.5f);

    GameObject waveTextObject = Instantiate(this.waveText, new Vector2(0, 0), Quaternion.identity);
    CanvasGroup waveTextGroup = waveTextObject.GetComponent<CanvasGroup>();

    TextMeshProUGUI textObject = waveTextObject.GetComponentInChildren<TextMeshProUGUI>();
    textObject.text = "Wave " + this.currentWave;

    waveTextGroup.alpha = 0f;
    while (waveTextGroup.alpha != 1f)
    {
      waveTextGroup.alpha += 0.1f;
      yield return new WaitForSeconds(.05f);
    }

    this.spawnEnemies();

    yield return new WaitForSeconds(1f);

    while (waveTextGroup.alpha != 0f)
    {
      waveTextGroup.alpha -= 0.1f;
      yield return new WaitForSeconds(.05f);
    }

    Destroy(waveTextObject);
    this.playing = true;
    yield return null;
  }

  private void spawnEnemies()
  {
    for (int i = 0; i < this.currentWaveStartingEnemyCount; i++)
    {
      float x = UnityEngine.Random.Range
          (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
      float y = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

      GameObject enemy = Instantiate(this.enemy, new Vector2(x, y), Quaternion.identity);
      this.enemyList.Add(enemy);
    }
  }

  private IEnumerator CompleteWave()
  {
    GameObject waveTextObject = Instantiate(this.waveText, new Vector2(0, 0), Quaternion.identity);
    CanvasGroup waveTextGroup = waveTextObject.GetComponent<CanvasGroup>();

    TextMeshProUGUI textObject = waveTextObject.GetComponentInChildren<TextMeshProUGUI>();
    textObject.text = "Noice! Get ready for the next one!";

    waveTextGroup.alpha = 0f;
    while (waveTextGroup.alpha != 1f)
    {
      waveTextGroup.alpha += 0.1f;
      yield return new WaitForSeconds(.05f);
    }

    yield return new WaitForSeconds(1f);

    while (waveTextGroup.alpha != 0f)
    {
      waveTextGroup.alpha -= 0.1f;
      yield return new WaitForSeconds(.05f);
    }

    Destroy(waveTextObject);
    StartCoroutine(this.BeginNextWave());

    yield return null;
  }

  private bool waveIsComplete()
  {
    return this.enemyList.Count == 0;
  }

  void Update()
  {
    if (this.playing && this.waveIsComplete())
    {
      this.playing = false;
      StartCoroutine(this.CompleteWave());
    }
  }
}
