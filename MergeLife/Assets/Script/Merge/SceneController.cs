using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<SceneController>();

            if (obj.Length == 1 )
            {
            Destroy(gameObject);
            }
            else
            {
            DontDestroyOnLoad(gameObject);
        }
    }
}
