using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private GameBehaviour gameManager;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }
    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.name == "Player") {
            Destroy(transform.parent.gameObject);
            Debug.Log("Item collected");

            gameManager.Items += 1;
        } 
    }
}
