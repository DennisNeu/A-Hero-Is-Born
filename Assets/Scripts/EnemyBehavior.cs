using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform patrolRoute;

    [SerializeField] private List<Transform> locations;

    private void Start() {
        InitializePatrolRoute();    
    }

    private void InitializePatrolRoute() {
        foreach(Transform child in patrolRoute) { }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Player detected!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Player lost!");
        }
    }
}
