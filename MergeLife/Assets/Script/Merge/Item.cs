using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DragManager))]
[RequireComponent(typeof(MoneyDragManager))]
public class Item : MonoBehaviour
{
    public int number;
    public string itemType; // 아이템 유형을 나타내는 필드

    [SerializeField] Color[] colors;

    public void SetItem(int newValue, string newItemType, Transform newParent)
    {
        number = newValue;
        itemType = newItemType; 
        GetComponent<Image>().color = SetColor(number);
        GetComponentInChildren<Text>().text = number.ToString();

        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;  
    }

    public Color SetColor(int colorValue)
    {
        if (colorValue <= colors.Length)
            return colors[colorValue - 1];
        else
            return Color.black;
    }
}

