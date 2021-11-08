﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.name == "Player") {
            Destroy(transform.parent.gameObject);
            Debug.Log("Item collected");
        } 
    }
}
