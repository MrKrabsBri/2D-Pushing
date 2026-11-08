using UnityEngine;
using UnityEngine.EventSystems;



public class InventorySlot : MonoBehaviour, IDropHandler {

    public ItemData item;
    public int amount;

    public bool isEmpty() {
        return item == null;
    }

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            GameObject droppedItem = eventData.pointerDrag;
            InventoryItem inventoryItem = droppedItem.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
