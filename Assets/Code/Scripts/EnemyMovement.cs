using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIdex = 0;

    private float baseSpeed;

    private void Start() {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIdex];
    }

    private void Update() {
        if (Vector2.Distance(target.position, transform.position) < 0.1) {
            pathIdex++;

            if (pathIdex == LevelManager.main.path.Length) {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                LevelManager.main.LoseHealth();
                return;
            } else {
                target = LevelManager.main.path[pathIdex];
            }
        }
    }

    private void FixedUpdate(){
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed) {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed(){
        moveSpeed = baseSpeed;
    }

    
}
