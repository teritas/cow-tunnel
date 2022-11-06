using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 0.4f;

    public GameObject playerLocation;
    private Rigidbody2D enemyBody;

    void Start()
    {
        enemyBody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((transform.position.x - playerLocation.transform.position.x) <= 8 && (transform.position.x - playerLocation.transform.position.x) >= -8)
        {
            Vector2 vel = new Vector2((transform.position.x - playerLocation.transform.position.x) * speed, enemyBody.velocity.y * -1.0f);
            enemyBody.velocity = -vel;
        }
        else
        {
            enemyBody.velocity = new Vector2(0, enemyBody.velocity.y);
        }

        if (transform.position.x - playerLocation.transform.position.x <= 0)
        {
            transform.transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
        else if (transform.position.x - playerLocation.transform.position.x > 0)
        {
            transform.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }
}
