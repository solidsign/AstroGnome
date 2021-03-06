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
    [Header("Excluded spawn area")]
    [SerializeField] private Vector2 minCoordsEx;
    [SerializeField] private Vector2 maxCoordsEx;
    [Header("Spawn Sounds")]
    [SerializeField] private List<AudioClip> sounds;
    private List<EnemyController> enemies;
    private float sumChance;
    private AudioSource audioSource;

    public Transform GetRandomAliveEnemy()
    {
        return enemies[Random.Range(0, enemies.Count)].transform;
    }

    public void DeleteEnemyFromList(EnemyController enemy)
    {
        enemies.Remove(enemy);
        SpawnEnemies(Random.Range(0, 3));
        StartCoroutine(DeleteEnemyFromScene(enemy));
    }

    public void AddNewPlayersObject(Transform obj)
    {
        PlayerAndAllies.Add(obj);
        int amount = Random.Range(0, enemies.Count / 3);
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

    public void StopAllEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<ComponentsDisabler>().DisableComponents();
        }

    }

    public void StopAllPlayersGuys()
    {
        foreach (var guy in PlayerAndAllies)
        {
            ComponentsDisabler componentsDisabler;
            if(guy.TryGetComponent<ComponentsDisabler>(out componentsDisabler))
            {
                componentsDisabler.DisableComponents();
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
        int index = Random.Range(0, PlayerAndAllies.Count);
        enemy.AttackPurpose = PlayerAndAllies[index];
    }
    private IEnumerator ChangeAttackPurposes()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            int index = Random.Range(0, enemies.Count);
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
                    float x = Random.Range(minCoords.x, maxCoords.x);
                    if(x < (minCoordsEx.x + maxCoordsEx.x) / 2f)
                    {
                        x = Mathf.Clamp(x, minCoords.x, minCoordsEx.x);
                    }
                    else
                    {
                        x = Mathf.Clamp(x, maxCoords.x, maxCoordsEx.x);
                    }

                    float y = Random.Range(minCoords.y, maxCoords.y);
                    if (y < (minCoordsEx.y + maxCoordsEx.y) / 2f)
                    {
                        y = Mathf.Clamp(y, minCoords.y, minCoordsEx.y);
                    }
                    else
                    {
                        y = Mathf.Clamp(y, maxCoordsEx.y, maxCoords.y);
                    }

                    Vector3 pos = new Vector3(x, y, 0f);
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
        audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(minCoords, 0.2f);
        Gizmos.DrawWireSphere(maxCoords, 0.2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(minCoordsEx, 0.2f);
        Gizmos.DrawWireSphere(maxCoordsEx, 0.2f);
    }
}
