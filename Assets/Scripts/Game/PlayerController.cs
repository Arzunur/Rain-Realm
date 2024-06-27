using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float growthFactor = 0.05f;
    public Actions actions;
    private Map map;


    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] public float baseSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        map = Map.Ins;
    }

    private void Update()
    {
        Move();

        if (transform.localScale.x >= 2 && Input.GetKey(KeyCode.Space))
        {
            GetComponent<Actions>().ThrowMass();
            GrowthFunction();
        }
    }

    private void FixedUpdate()
    {
        AdjustSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        WaterDrop waterDrop = other.GetComponent<WaterDrop>();
        if (waterDrop != null)
        {
            GrowthFunction();
            Destroy(other.gameObject);
            SoundManager.Instance.PlayCollectItemSound();
        }
    }
    #region Move
    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float clampedX = Mathf.Clamp(targetPosition.x, -map.MapLimit.x, map.MapLimit.x );
        float clampedY = Mathf.Clamp(targetPosition.z, -map.MapLimit.y, map.MapLimit.y);

        targetPosition = new Vector3(clampedX, transform.position.y, clampedY);

        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
    #endregion

    public void AdjustSpeed()// Karakter buyudukce hýzýnýn ayarlanmasi
    {
        float adjustedSpeed = baseSpeed / transform.localScale.x;
        speed = adjustedSpeed;
    }

    private void GrowthFunction()
    {
        transform.localScale += new Vector3(growthFactor, growthFactor, growthFactor);
    }
}




