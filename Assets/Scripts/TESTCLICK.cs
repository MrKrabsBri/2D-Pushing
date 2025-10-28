using UnityEngine;
using UnityEngine.EventSystems;

public class MyClickHandler : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Clicked!");
    }
}
