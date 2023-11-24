using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Transform limitL;
    public Transform limitR;
    public Transform limitB;

    public GameObject drop;
    public Bullet bullet;
    public Player player;

    public float speed = 0.05f;

    private float offset = 1.0f;

    public int defaultHp = 5;
    private int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = defaultHp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;

        if (transform.position.x < limitL.position.x) {
            transform.position = new Vector3(limitR.position.x, transform.position.y - offset, transform.position.z);
        }

        if (transform.position.y < limitB.position.y)
        {
            player.updateScore(-1);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet)
        {
            
        }
    }

    public void takeDamage() {
        currentHp -= 1;
        if (currentHp < 0) {
            currentHp = 0;
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}