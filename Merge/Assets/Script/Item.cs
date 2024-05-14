using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (DragManager))]

public class Item : MonoBehaviour
{

    public int number;

    [SerializeField] Color[] colors;

    public void SetItem(int newValue, Transform newParent)
    {
        number = newValue;
        GetComponent<Image>().color = SetColor(number);
        GetComponentInChildren<Text>().text = number.ToString();

        transform.SetParent(newParent);
    }

    public Color SetColor(int colorvalue)
    {
        if (colorvalue < 10)
            return colors[colorvalue - 1];
        else
            return Color.black;
    }
}
