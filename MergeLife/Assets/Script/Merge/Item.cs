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
    public string itemType; // ������ ������ ��Ÿ���� �ʵ�

    [SerializeField] Color[] colors;

    public void SetItem(int newValue, string newItemType, Transform newParent)
    {
        number = newValue;
        itemType = newItemType; // ������ ���� ����
        GetComponent<Image>().color = SetColor(number);
        GetComponentInChildren<Text>().text = number.ToString();

        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;  // ��ġ �ʱ�ȭ
    }

    public Color SetColor(int colorValue)
    {
        if (colorValue <= colors.Length)
            return colors[colorValue - 1];
        else
            return Color.black;
    }
}

