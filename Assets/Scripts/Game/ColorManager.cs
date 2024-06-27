using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager ins;

    [SerializeField] private Color[] Colors;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetRandomColorForSecondChild(GameObject parentObject)
    {
        if (Colors.Length > 0)
        {
            int r = Random.Range(0, Colors.Length);
            if (parentObject.transform.childCount > 1)
            {
                Transform secondChild = parentObject.transform.GetChild(1); 

                Renderer renderer = secondChild.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Colors[r];
                }
                else
                {
                    Debug.LogWarning("Renderer component not child");
                }
            }
        }
        else
        {
            Debug.LogWarning("Colors array is empty");
        }
    }
}

