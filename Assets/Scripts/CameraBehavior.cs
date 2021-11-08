using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);

        transform.LookAt(target);
    }
}
