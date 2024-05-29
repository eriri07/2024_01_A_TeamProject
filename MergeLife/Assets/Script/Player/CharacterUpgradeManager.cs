using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgradeManager : MonoBehaviour
{
    public GameObject newCharacterPrefab; // 교체할 캐릭터 프리팹
    public Transform canvasTransform; // 새 캐릭터를 생성할 캔버스 Transform

    private int mergeCount = 0; // 머지 카운트

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
            // 기존 캐릭터 삭제
            Destroy(gameObject);

            // 새 캐릭터 생성 및 캔버스 내에서 활성화
            GameObject newCharacterInstance = Instantiate(newCharacterPrefab, canvasTransform);
            RectTransform newCharacterRectTransform = newCharacterInstance.GetComponent<RectTransform>();

            if (newCharacterRectTransform != null)
            {
                // 캔버스 내에서 위치와 크기를 현재 캐릭터와 동일하게 설정
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