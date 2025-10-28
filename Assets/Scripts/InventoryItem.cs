using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI itemCountText;

    [SerializeField] private GameObject frameSelected;
    [SerializeField] public bool itemIsClicked = false;

    [HideInInspector] public Item item;
    [HideInInspector] public int itemCount = 1;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int selectedItemNumber;

    public void setFrameSelected(GameObject frameSelected) {
        this.frameSelected = frameSelected;
    }

    public GameObject getFrameSelected() {
        return frameSelected;
    }


    public void OnPointerClick(PointerEventData eventData) {

        // Tell the manager to change selected slot
        InventoryManager.Instance.ChangeSelectedSlot(this);
    }

    private void DisableAllFrames() {
        Transform rootCanvas = transform.root;
        if (rootCanvas == null) return;

        // Find all InventoryItem scripts under it
        InventoryItem[] allItems = rootCanvas.GetComponentsInChildren<InventoryItem>(true);

        foreach (var item in allItems) {
            if (item.frameSelected != null)
                item.frameSelected.SetActive(false);
        }
        Debug.Log("Disabled all frames");
    }

    public void InitializeItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.image;
        RefreshItemCountText();
    }

    public void RefreshItemCountText() {
        bool textActive = false;
        itemCountText.text = itemCount.ToString();
        if (item.stackable) {
            //textActive = itemCount > 1; // jei noresiu paslept skaiciu, kai count = 1
            textActive = true;
        }

        itemCountText.gameObject.SetActive(textActive); // jei noresiu paslept skaiciu, kai count = 1
    }

    public void OnBeginDrag(PointerEventData eventData) {
/*        if (frameSelected != null)
            frameSelected.SetActive(true); // frame enabled on drag*/
        DisableAllFrames();
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Debug.Log("start dragging");
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        Debug.Log("ending dragging");
    }
}

