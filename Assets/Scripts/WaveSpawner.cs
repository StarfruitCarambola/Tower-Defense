using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;
    private int waveIndex = 0;

    void Update()
    {
        timeBetweenWaves = 6f + (float)((int)PlayerStats.Rounds / 30);
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //this is what helps creates spacing when we spawn new waves of enemies or else they will overlap
            countdown = timeBetweenWaves;
            //when the countdown timer reaches 0, spawn a new wave and then reset the timer
        }

        countdown -= Time.deltaTime;
        //reduces the countdown by 1 every second

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex = (int)timeBetweenWaves;
        PlayerStats.Rounds++;
        //increases the amount of enemies each wave

        for (float i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            if ((0.5f - PlayerStats.Rounds / 10f) < .2f)
                yield return new WaitForSeconds(0.2f);
            else
                yield return new WaitForSeconds(0.5f - PlayerStats.Rounds / 10f);
            //each new enemy for each wave will have a 0.5 second delay
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //spawn enemies at that position we set it as. In this case, it is the start position.
    }


}