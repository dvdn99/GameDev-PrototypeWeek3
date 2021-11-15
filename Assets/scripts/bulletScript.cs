using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        JhonMovement jhon = colision.GetComponent<JhonMovement>();
        enemyScript enemy = colision.GetComponent<enemyScript>();

        if (jhon != null)
        {
            jhon.Hit();
        }
        if (enemy != null)
        {
            enemy.Hit();
        }
        DestroyBullet();
    }

}
