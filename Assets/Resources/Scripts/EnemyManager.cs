using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> PlayerAndAllies;

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<float> spawnChances;
    [SerializeField] private int amountOfStartSpawn;
    [SerializeField] private int spawnEmmision;
    [Header("Spawn Area")]
    [SerializeField] private Vector2 minCoords;
    [SerializeField] private Vector2 maxCoords;

    private List<EnemyController> enemies;
    private float sumChance;


    public void DeleteEnemyFromList(EnemyController enemy)
    {
        enemies.Remove(enemy);
        SpawnEnemies(Mathf.CeilToInt(Random.Range(0f, 2f)));
    }

    public void AddNewPlayersObject(Transform obj)
    {
        PlayerAndAllies.Add(obj);
        int amount = Mathf.RoundToInt(Random.Range(1f, enemies.Count / 3));
        int startIndex = Mathf.CeilToInt(Random.Range(0f, enemies.Count - amount));
        for (int i = startIndex; i < startIndex + amount; i++)
        {
            enemies[i].AttackPurpose = obj;
        }
    }

    private void Start()
    {
        foreach (var chance in spawnChances)
        {
            sumChance += chance;
        }
        enemies = new List<EnemyController>(amountOfStartSpawn * 2);
        SpawnEnemies(amountOfStartSpawn);
        StartCoroutine(ChangeAttackPurposes());
    }

    private void SetNewAttackPurpose(EnemyController enemy)
    {
        int index = Mathf.CeilToInt(Random.Range(0f, PlayerAndAllies.Count - 1));
        enemy.AttackPurpose = PlayerAndAllies[index];
    }
    private IEnumerator ChangeAttackPurposes()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            int index = Mathf.CeilToInt(Random.Range(0f, enemies.Count));
            SetNewAttackPurpose(enemies[index]);
        }
    }

    private void SpawnEnemies(int amount)
    {
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
}
