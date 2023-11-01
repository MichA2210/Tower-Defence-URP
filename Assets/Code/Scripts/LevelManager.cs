using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    [SerializeField] TextMeshProUGUI baseHealth;
    [SerializeField] TextMeshProUGUI waveText;

    public Transform startPoint;
    public Transform[] path;

    [Header("Attributes")]
    public int currency;
    public int health = 100;
    private EnemySpawner wave = new EnemySpawner();

    private void Awake() {
        main = this;
    }

    private void Start() {
        currency = 100;
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
    }

    public bool SpendCurrency(int amount) {
        if (amount <= currency){
            currency -= amount;
            return true;
        } else {
            Debug.Log("Not enough money");
            return false;
        }
    }

    private void Update() {
        if (health <= 0) {
            SceneManager.LoadScene(3);
            Debug.Log("Dead");
        }
    }

    private void OnGUI() {
        baseHealth.text = "Health: " + health.ToString();
        waveText.text = "Wave: " + wave.GetWave().ToString();
    }

    public void LoseHealth() {
        health--;
    }
    
}