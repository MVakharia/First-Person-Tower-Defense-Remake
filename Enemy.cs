using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Core nearestCore;

    [SerializeField]
    private float moveSpeed;

    private void SelfDestruct ()
    {
        Destroy(gameObject);
    }


    private void Start()
    {
        nearestCore = GameObject.FindGameObjectWithTag("Core").GetComponent<Core>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nearestCore.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Core"))
        {
            
        }
    }
}