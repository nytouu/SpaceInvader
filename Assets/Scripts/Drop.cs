using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float speed = 0.005f;
    private Player player;
    // public Transform limitB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        
        // if (transform.position.y < limitB.position.y) {
        //     Destroy(gameObject);
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            Destroy(gameObject);
        }
    }
}
