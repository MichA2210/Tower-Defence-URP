using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI upgradeCost;

    public Turret torret;

    public bool mouse_over = false;

    public void OnPointerEnter(PointerEventData eventData) {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouse_over = false;
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }

    private void OnGUI() {
        upgradeCost.text = torret.CalculateCost().ToString();
    }
}
