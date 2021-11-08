using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
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
