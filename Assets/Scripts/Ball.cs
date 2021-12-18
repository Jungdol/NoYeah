using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]public Vector3 Pos { get { return transform.position; } }
    public int junmpcnt=1;
    public float time;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        junmpcnt = 0;
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    public void DesActivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        junmpcnt = 0;
        time += Time.deltaTime;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        junmpcnt +=1;
        time = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        junmpcnt = 0;
        
    }
}
