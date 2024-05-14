using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IDropHandler 상속을 위한
public class Slot : MonoBehaviour, IDropHandler
{
    //이전 포스팅의 Icon함수를 대체 하는 프로퍼티
    public GameObject item
    {
        // item에 접근하려고 할때(읽을 때) 실행
        get
        {
            // transform (rect transform)에 자식 존재여부 확인
            if (transform.childCount > 0)
            {
                // 슬롯에 아이템이 있으면 아이템의 gameobject를 리턴
                return transform.GetChild(0).gameObject;
            }
            // 슬롯에 아이템이 없다면 null을 리턴
            return null;
        }
    }

    // 스크립트가 부착된 RectTransform에 포인터가 놓여질때 해당 이벤트가 발생 
    public void OnDrop(PointerEventData eventData)
    {
        // 슬롯이 비어있다면 실행
        if (!item)
        {
            // 이전 포스팅에 존재하던 위치보정 코드는 슬롯게임오브젝트에
            // grid layout group을 추가하여 자동 위치 보정되도록 변경 
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else // 슬롯이 비어있지 않다면 실행
        {
            //아이템 간 위치변경 또는 병합을 위한 두 아이템 참조
            Item dragItem = DragManager.beingDraggedItem.GetComponent<Item>();
            Item soltItem = item.GetComponent<Item>();

            // 두 아이템의 숫자가 동일한 경우 실행
            if (dragItem.number == soltItem.number)
            {
                //숫자 백업 후 병합 될 두 아이템 모두 Destory
                int backupNum = dragItem.number;
                Destroy(dragItem.gameObject); Destroy(soltItem.gameObject);

                //인벤트리 매니저를 통해 상위 아이템을 생성
                InventoryManager.inst.CreateUpgradeItem(backupNum + 1, transform);
            }
            else // 두 아이템의 숫자가 다른경우 위치변경
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);
                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
            }
        }
    }
}
