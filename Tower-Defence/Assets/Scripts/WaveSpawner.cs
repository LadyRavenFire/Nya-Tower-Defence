using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform EnemyPrefab;
    public Transform SpawnPoint;

    public float TimeBetweenWawes = 5f;
    public float TimeBetweenSpawn = 0.5f;
    private float _countdown = 5.5f;

    public Text WaveCountDownText;

    private int _waveIndex = 0;

    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = TimeBetweenWawes;
        }

        _countdown -= Time.deltaTime;

        WaveCountDownText.text = Mathf.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
