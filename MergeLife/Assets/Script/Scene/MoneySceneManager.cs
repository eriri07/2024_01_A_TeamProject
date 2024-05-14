using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneySceneManager : MonoBehaviour
{
    public void MoneyScene()
    {
        SceneManager.LoadScene("MoneyScene");
    }

    public void BabyScene()
    {
        SceneManager.LoadScene("BabyScene");
    }
}
