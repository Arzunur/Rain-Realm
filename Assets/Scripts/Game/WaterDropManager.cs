using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    public static WaterDropManager Instance;

    [SerializeField] public GameObject WaterDropPrefab;
    [SerializeField] public List<GameObject> CreatedDrops = new List<GameObject>();
    [SerializeField] private int maxDrops = 20; //Max damla sayisi
    [SerializeField] private float createInterval = 0.5f;


    private Coroutine spawnCoroutine;
    private Map map;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        map = Map.Ins;
        StartSpawning();

    }

    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnWaterDropRoutine());
        }
    }
    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
    private IEnumerator SpawnWaterDropRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(createInterval);

            if (CreatedDrops.Count < maxDrops)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-map.MapLimit.x, map.MapLimit.x), 1f, Random.Range(-map.MapLimit.y, map.MapLimit.y));
                Quaternion rotation = Quaternion.Euler(-90f, 180f, 0f);

                GameObject newDrop = Instantiate(WaterDropPrefab, spawnPosition, rotation);
                AddCreatedDrop(newDrop);

                // RandomSize bileþenini kullanarak rastgele boyut ayarý yap
                RandomSize randomSize = newDrop.GetComponent<RandomSize>();
                if (randomSize != null)
                {
                    randomSize.ApplyRandomSize();
                }
                else
                {
                    Debug.LogWarning("Yeni damla RandomSize bileþenine sahip deðil!");
                }
                Renderer renderer = newDrop.GetComponent<Renderer>();
                if (renderer != null)
                {
                    ColorManager.ins.GetRandomColorForSecondChild(newDrop);

                }
            }
            else
            {
                StopSpawning();
            }
        }
    }
    public void AddCreatedDrop(GameObject dropObject)
    {
        if (dropObject != null && !CreatedDrops.Contains(dropObject))
        {
            CreatedDrops.Add(dropObject);
        }
    }
    public void RemoveCreatedDrop(GameObject dropObject)
    {
        if (dropObject != null && CreatedDrops.Contains(dropObject))
        {
            CreatedDrops.Remove(dropObject);
            Destroy(dropObject);
        }
    }
}