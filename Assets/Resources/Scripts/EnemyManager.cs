using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> PlayerAndAllies;

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<float> spawnChances;
    [SerializeField] private int amountOfStartSpawn;
    [SerializeField] private int spawnEmmision;
    [SerializeField] private int maxNumberOfEnemies;
    [Header("Spawn Area")]
    [SerializeField] private Vector2 minCoords;
    [SerializeField] private Vector2 maxCoords;
    [Header("Spawn Sounds")]
    [SerializeField] private List<AudioClip> sounds;
    private List<EnemyController> enemies;
    private float sumChance;
    private AudioSource audioSource;

    public Transform GetRandomAliveEnemy()
    {
        return enemies[Random.Range(0, enemies.Count - 1)].transform;
    }

    public void DeleteEnemyFromList(EnemyController enemy)
    {
        enemies.Remove(enemy);
        SpawnEnemies(Random.Range(0, 2));
        StartCoroutine(DeleteEnemyFromScene(enemy));
    }

    public void AddNewPlayersObject(Transform obj)
    {
        PlayerAndAllies.Add(obj);
        int amount = Random.Range(1, enemies.Count / 3);
        int startIndex = Random.Range(0, enemies.Count - amount);
        for (int i = startIndex; i < startIndex + amount; i++)
        {
            enemies[i].AttackPurpose = obj;
        }
    }

    public void DeletePlayersObject(Transform obj)
    {
        PlayerAndAllies.Remove(obj);
        foreach (var enemy in enemies)
        {
            if(enemy.AttackPurpose == obj)
            {
                SetNewAttackPurpose(enemy);
            }
        }
    }

    private IEnumerator DeleteEnemyFromScene(EnemyController enemy)
    {
        yield return new WaitForSeconds(5f);
        Destroy(enemy.gameObject);
    }

    private void Start()
    {
        foreach (var chance in spawnChances)
        {
            sumChance += chance;
        }
        enemies = new List<EnemyController>(maxNumberOfEnemies);
        audioSource = GetComponent<AudioSource>();
        SpawnEnemies(amountOfStartSpawn);
        StartCoroutine(ChangeAttackPurposes());
    }

    private void SetNewAttackPurpose(EnemyController enemy)
    {
        int index = Random.Range(0, PlayerAndAllies.Count - 1);
        enemy.AttackPurpose = PlayerAndAllies[index];
    }
    private IEnumerator ChangeAttackPurposes()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            int index = Random.Range(0, enemies.Count - 1);
            SetNewAttackPurpose(enemies[index]);
        }
    }

    private void SpawnEnemies(int amount)
    {
        amount = Mathf.Clamp(amount, 0, maxNumberOfEnemies - enemies.Count);
        if (amount == 0) return;
        Invoke(nameof(PlaySpawnSound), 0.05f);
        for (int i = 0; i < amount; i++)
        {
            float res = Random.Range(0f, sumChance);
            float chanceChecker = spawnChances[0];
            int chanceIndex = 0;
            foreach (var chance in spawnChances)
            {
                if(res <= chanceChecker)
                {
                    Vector3 pos = new Vector3(Random.Range(minCoords.x, maxCoords.x), Random.Range(minCoords.y, maxCoords.y), 0);
                    GameObject enem = Instantiate(enemyPrefabs[chanceIndex], pos, Quaternion.Euler(0,0,0));
                    EnemyController enemy = enem.GetComponent<EnemyController>();
                    enemy.Manager = this;
                    enemies.Add(enemy);
                    SetNewAttackPurpose(enemy);
                    break;
                }
                ++chanceIndex;
                chanceChecker += spawnChances[chanceIndex];
            }
        }
    }

    private void PlaySpawnSound()
    {
        audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Count - 1)]);
    }
}
