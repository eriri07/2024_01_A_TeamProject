using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Image[] endingImages; // 엔딩 이미지 배열
    public Sprite[] unlockedEndingSprites; // 해금된 엔딩 이미지 배열
    public Sprite lockedEndingSprite; // 잠금 상태의 엔딩 이미지를 위한 스프라이트

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
