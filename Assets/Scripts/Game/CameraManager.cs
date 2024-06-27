using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float baseHeight = 200f; 
    [SerializeField] private float distanceFactor = 3f; // Karakterin buyuklugune gore mesafeyi belirleyen carpan

    void LateUpdate()
    {
        // karakterin scale degerine gore kameranin mesafesini ayarlar
        float characterScale = character.localScale.x;
        float height = baseHeight + characterScale * distanceFactor;
        Vector3 followPosition = character.position - character.forward * distanceFactor + Vector3.up * height;
        transform.position = followPosition;
        transform.LookAt(character.position);
    }

}
