using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement2D : MonoBehaviour
{
    public float speed = 9;
    public float jumpHeight = 12;
    [SerializeField] private LayerMask goalLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;
    public bool atGoal = false;
    public bool touchEnemy = false;

    private Rigidbody2D body;

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetKey("a"))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
            transform.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey("d"))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
            transform.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            body.velocity = Vector2.up * jumpHeight;
        }

        if (IsBoundary() || touchEnemy)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (atGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    private bool IsBoundary()
    {
        return transform.Find("GroundCheck").GetComponent<BoundaryCheck>().isBoundary;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        atGoal = collider != null && (((1 << collider.gameObject.layer) & goalLayerMask) != 0);
        touchEnemy = collider != null && (((1 << collider.gameObject.layer) & enemyLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atGoal = false;
        touchEnemy = false;
    }
}
