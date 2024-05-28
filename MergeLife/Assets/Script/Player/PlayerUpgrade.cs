using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int number;
    GameObject obj;

    void CharacterUpgrade(int newNumber, Transform newParent)
    {
        obj = GameObject.Find("Item");
        obj.GetComponent<Item>().SetItem(4, newParent);
        
        if (number >= 4)
        {
            
        }
    }
}
