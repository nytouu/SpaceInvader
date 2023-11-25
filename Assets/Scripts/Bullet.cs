using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject drops;
    public Rigidbody2D monRigidBody;
    public float speed;
    public Ennemy ennemy;
    // public Transform limitU;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    private void Update()
    {
        
        // if (transform.position.y > limitU.position.y) {
        //     Destroy(gameObject);
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ennemy = collision.gameObject.GetComponent<Ennemy>();
        if (ennemy)
        {
            ennemy.takeDamage();
            Destroy(gameObject);
        }
    }
}
