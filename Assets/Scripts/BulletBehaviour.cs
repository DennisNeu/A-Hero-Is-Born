using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float onscreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, onscreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
