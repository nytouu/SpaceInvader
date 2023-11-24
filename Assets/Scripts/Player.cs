using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum Direction {
    Left,
    Right,
}

enum FireType
{
    SemiAuto,
    FullAuto
}

public class Player :MonoBehaviour {
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public Drop drop;
    public TrailRenderer trail;
    public TextMeshProUGUI scoreText;

    public float defaultSpeed = 0.1f;
    public int dashDuration = 60;
    private float currentSpeed;

    private int score = 0;

    private bool isDashing = false;
    private bool canDash = true;
    private Direction currentDirection;
    private int dashCounter = 0;

    // Start is called before the first frame update
    void Start() {
        currentSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update() {
        handleInput();

        // Debug.Log(dashCounter);

        if (transform.position.x < limitL.position.x) {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x) {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }

    public void updateScore(int incr) {
        score += incr;
        scoreText.SetText(score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        drop = collision.gameObject.GetComponent<Drop>();
        if (drop) {
            Destroy(drop.gameObject);
            updateScore(1);
        }
    }

    private void handleInput() {
        if (!isDashing) {
            trail.emitting = false;

            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.position += Vector3.left * currentSpeed;
                currentDirection = Direction.Left;

                if (canDash) checkDash();
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.position += Vector3.right * currentSpeed;
                currentDirection = Direction.Right;

                if (canDash) checkDash();
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                Instantiate(bullet, parent.position, parent.rotation);
            }
        } else {
            trail.emitting = true;

            if (dashCounter >= dashDuration) {
                dashCounter = 0;
                isDashing = false;
                canDash = true;
                currentSpeed = defaultSpeed;
            } else if (dashCounter >= 1) {
                dashCounter++;

                switch (currentDirection) {
                    case Direction.Left:
                        transform.position += Vector3.left * currentSpeed;
                        break;
                    case Direction.Right:
                        transform.position += Vector3.right * currentSpeed;
                        break;
                }
            }
        }
    }

    private void checkDash() {
        if (Input.GetKey(KeyCode.LeftShift) && !isDashing && dashCounter == 0) {
            playerDash();
        }
    }

    private void playerDash() {
        isDashing = true;
        canDash = false;
        currentSpeed = defaultSpeed * 3;
        dashCounter = 1;
    }
}