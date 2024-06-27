using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stoppingDistance = 2f;
    [SerializeField] private float retreatDistance = 5f;
    [SerializeField] private float enemyRadius = 22f;
    [SerializeField] private float followDistance = 10f;


    void Update()
    {
     if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= followDistance) // Oyuncu belirli bir mesafeye yaklastiginda takip etmeye baþla
        {
            if (distance > stoppingDistance) 
            {
                Vector3 moveDirection = (target.position - transform.position).normalized;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
            else if (distance < retreatDistance) 
            {
                Vector3 moveDirection = (transform.position - target.position).normalized;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }

            PreventCollisions();
        }

    }

    void PreventCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != gameObject && collider.GetComponent<EnemyAI>() != null)
            {
                Vector3 avoidDirection = (transform.position - collider.transform.position).normalized;
                transform.position += avoidDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}


