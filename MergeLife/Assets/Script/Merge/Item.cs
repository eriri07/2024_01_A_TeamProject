/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DragManager))]
public class Item : MonoBehaviour
{
    public int number;
    public string itemType; // 아이템 유형을 나타내는 필드

    [SerializeField] Color[] colors;

    public void SetItem(int newValue, string newItemType, Transform newParent)
    {
        number = newValue;
        itemType = newItemType; // 아이템 유형 설정
        GetComponent<Image>().color = SetColor(number);
        GetComponentInChildren<Text>().text = number.ToString();

        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;  // 위치 초기화
    }

    public Color SetColor(int colorValue)
    {
        if (colorValue <= colors.Length)
            return colors[colorValue - 1];
        else
            return Color.black;
    }
}

