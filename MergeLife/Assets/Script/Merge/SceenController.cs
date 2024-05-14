using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenController : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<SceenController>();

            if (obj.Length == 1 )
            {
            DontDestroyOnLoad(gameObject);
            }
            else
            {
            Destroy(gameObject);
            }
    }
}
