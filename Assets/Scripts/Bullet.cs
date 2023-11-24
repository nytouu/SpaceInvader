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

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    private void Update()
    {
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
