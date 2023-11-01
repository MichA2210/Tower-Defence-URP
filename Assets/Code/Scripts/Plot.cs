using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject towerObj;
    public Turret turret;
    private Color startColor;

    private void Start() {
        startColor = sr.color;
    }

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private void OnMouseExit() {
        sr.color = startColor;
    }

    private void OnMouseDown() {
        if (UIManager.main.IsHoveringUI()) return;

        if (towerObj != null) {
            turret.OpenUpgradeUI();
            return;
        }

        Tower tempTower = BuildManager.main.GetSelectedTower();

        if (tempTower.cost > LevelManager.main.currency) {
            Debug.Log("Not enough money");
            return;
        }

        LevelManager.main.SpendCurrency(tempTower.cost);

        towerObj = Instantiate(tempTower.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
    }
    
}
