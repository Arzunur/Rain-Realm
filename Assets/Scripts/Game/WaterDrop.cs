using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start() => scoreManager = GameObject.FindObjectOfType<ScoreManager>();
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.CollectWaterDrop(gameObject);
            // Destroy(gameObject);
            WaterDropManager.Instance.RemoveCreatedDrop(gameObject);
        }
    }
}
