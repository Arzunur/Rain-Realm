using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Ins;
    Map map;

    public GameObject Enemy;
    public List<GameObject> Enemys = new List<GameObject>();

    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private int MaxEnemy;


    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
    }

    void Start()
    {
        map = Map.Ins;
        InvokeRepeating("InstantiateEnemy", 1, spawnInterval);
    }
    public void InstantiateEnemy()
    {
        if (Enemys.Count >= MaxEnemy)
        {
            return;
        }
       
        Vector3 spawnPosition = new Vector3(Random.Range(-map.MapLimit.x / 2, map.MapLimit.x / 2), 1f, Random.Range(-map.MapLimit.y / 2, map.MapLimit.y / 2));
        GameObject NewEnemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);
        ColorManager.ins.GetRandomColorForSecondChild(NewEnemy);
    }
    public void AddEnemyUfo(GameObject Ufo)
    {
        Enemys.Add(Ufo);
    }
    public void RemoveEnemyUfo(GameObject Ufo)
    {
        Enemys.Remove(Ufo);
    }
}
