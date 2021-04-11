using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Core nearestCore;

    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        nearestCore = GameObject.FindGameObjectWithTag("Core").GetComponent<Core>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nearestCore.transform.position, moveSpeed * Time.deltaTime);
    }
}
