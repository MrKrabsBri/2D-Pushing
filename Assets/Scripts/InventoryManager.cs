using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public int maxStackItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    int selectedSlot = -1;
    InventoryItem inventoryItem;
    private InventoryItem selectedItem;
    // [SerializeField] private GameObject frameSelected;

    public static InventoryManager Instance { get; private set; }

    private void Awake() {
        Instance = this; // simple singleton for access
    }

    public void ChangeSelectedSlot(InventoryItem clickedItem) {

        //bool isNowSelected = !frameSelected.activeSelf;

        if (selectedItem == clickedItem) {
            // Deselect if already selected
            clickedItem.getFrameSelected().SetActive(false);
            selectedItem = null;
            selectedSlot = -1;//####################
            return;
        }

        // Disable all frames first
        foreach (InventorySlot slot in inventorySlots) {
            InventoryItem item = slot.GetComponentInChildren<InventoryItem>(true);
            if (item != null && item.getFrameSelected() != null)
                item.getFrameSelected().SetActive(false);
        }

        // Enable the clicked one
        if (clickedItem != null && clickedItem.getFrameSelected() != null)
            clickedItem.getFrameSelected().SetActive(true);

        selectedItem = clickedItem;

        for (int i = 0; i < inventorySlots.Length; i++) {
            InventoryItem itemInSlot = inventorySlots[i].GetComponentInChildren<InventoryItem>(true);
            if (itemInSlot == clickedItem) {
                selectedSlot = i;
                break;
            }
        }
    }


    public bool AddItemToNextEmptySlot(Item item) {

        // Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.itemCount < maxStackItems
            && itemInSlot.item.stackable == true) {
                itemInSlot.itemCount++;
                itemInSlot.RefreshItemCountText();
                return true;
            }
        }

        //find first empty slot
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null) {
                SpawnNewItemInSlot(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItemInSlot(Item item, InventorySlot inventorySlot) {
        GameObject newItemGameObject = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public void SetSelectedItem(InventoryItem item) { // O gal scriptable object ITEM?
        selectedItem = item;
    }

    public Item GetSelectedItem(bool itemInUse) { // 28min rodo sita vieta, 29 vieta su use item
        if (selectedSlot >= 0) {
            InventorySlot slot = inventorySlots[selectedSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) {
                Item item = itemInSlot.item;
                if (itemInUse) {
                    itemInSlot.itemCount--;
                    if (itemInSlot.itemCount <= 0) { 
                        Destroy(itemInSlot.gameObject);  
                        // TODO: FIX STACKABLE ITEMS, SO THAT COUNT ALWAYS SHOWS IF TYPE IS STACKABLE.
                    }
                    else {
                        itemInSlot.RefreshItemCountText();
                    }
                }
                return item;
            }
        }

        return null;
    }


    /*    public Item GetSelectedItem() {
            InventorySlot slot = inventorySlots[selectedSlot]; // GET THIS IN OTHER METHOD
            //InventorySlot slot = inventoryItem.Change
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) {
                return itemInSlot.item;
            }
            return null;
            // turbut reiks refactor code is inventoryItem i inentoryManager, now we dont know which field is selected, only the frame is changing.
        }*/
}
