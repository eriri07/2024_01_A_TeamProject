using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgradeManager : MonoBehaviour
{
    public GameObject newCharacterPrefab; // ��ü�� ĳ���� ������
    public Transform canvasTransform; // �� ĳ���͸� ������ ĵ���� Transform

    private int mergeCount = 0; // ���� ī��Ʈ

    public void OnItemMerged(int newNumber)
    {
        if (newNumber == 4)
        {
            mergeCount++;
            CheckMergeCount();
        }
    }

    void CheckMergeCount()
    {
        if (mergeCount >= 1)
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        if (newCharacterPrefab != null && canvasTransform != null)
        {
            // ���� ĳ���� ����
            Destroy(gameObject);

            // �� ĳ���� ���� �� ĵ���� ������ Ȱ��ȭ
            GameObject newCharacterInstance = Instantiate(newCharacterPrefab, canvasTransform);
            RectTransform newCharacterRectTransform = newCharacterInstance.GetComponent<RectTransform>();

            if (newCharacterRectTransform != null)
            {
                // ĵ���� ������ ��ġ�� ũ�⸦ ���� ĳ���Ϳ� �����ϰ� ����
                newCharacterRectTransform.SetParent(canvasTransform, false);
                newCharacterRectTransform.anchoredPosition = Vector2.zero;
                newCharacterRectTransform.localRotation = Quaternion.identity;
                newCharacterRectTransform.localScale = Vector3.one;
                newCharacterRectTransform.sizeDelta = Vector2.zero;
            }
            else
            {
                Debug.LogWarning("RectTransform component is missing on the character prefab.");
            }

            Debug.Log("Character switched!");
        }
        else
        {
            Debug.LogWarning("Missing new character prefab or canvas transform.");
        }
    }
}