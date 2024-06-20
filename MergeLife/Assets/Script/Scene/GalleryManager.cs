using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Image[] endingImages; // ���� �̹��� �迭
    public Sprite[] unlockedEndingSprites; // �رݵ� ���� �̹��� �迭
    public Sprite lockedEndingSprite; // ��� ������ ���� �̹����� ���� ��������Ʈ

    void Start()
    {
        for (int i = 0; i < endingImages.Length; i++)
        {
            bool isEndingUnlocked = PlayerPrefs.GetInt("EndingUnlocked_" + i, 0) == 1;

            if (isEndingUnlocked)
            {
                endingImages[i].sprite = unlockedEndingSprites[i];
            }
            else
            {
                endingImages[i].sprite = lockedEndingSprite;
            }
        }
    }
}
