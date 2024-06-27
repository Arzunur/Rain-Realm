using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject MassPrefab;
    private GameObject currentMassObject;
    public Transform MassSpawnPoint; 

    [SerializeField] private float percentage = 0.1f;


    private void Start()
    {
        if (MassPrefab == null)
        {
            Debug.LogError("Mass Prefab is not assigned in Actions script");
        }
    }

    public void ThrowMass()
    {
        if (transform.localScale.x <= 2)
        {
            return;
        }

        if (MassSpawnPoint != null)
        {
            Quaternion rotation = Quaternion.Euler(-90f, 180f, 0f);
            currentMassObject = Instantiate(MassPrefab, MassSpawnPoint.position, rotation);
            Rigidbody rb = currentMassObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = currentMassObject.AddComponent<Rigidbody>();
            }
            rb.useGravity = false;
            float newScaleValue = transform.localScale.x - percentage;
            transform.localScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
        }
        else
        {
            Debug.LogError("Mass Spawn Point is not assigned in Actions script");
        }
    }
}
