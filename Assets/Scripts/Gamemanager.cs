using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Camera cam;
    public Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;
    bool isDragging = false;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        cam = Camera.main;
        ball.DesActivateRb();
    }
    private void Update()
    {
        if (ball.blacksnata == true)
        {
            if (ball.junmpcnt < 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isDragging = true;
                    OnDragStart();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    ball.junmpcnt += 1;
                    isDragging = false;
                    OnDragEnd();
                }
                if (isDragging)
                {
                    OnDrag();
                }
            }
        }
        else if (ball.junmpcnt < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ball.junmpcnt += 1;
                isDragging = false;
                OnDragEnd();
            }
            if (isDragging)
            {
                OnDrag();
            }
        }
    }
    void OnDragStart()
    {
            ball.DesActivateRb();
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            trajectory.Show();
    }
    void OnDrag()
    {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            trajectory.UpdateDots(ball.Pos, force);
    }
    void OnDragEnd()
    {
        ball.ActivateRb();
        ball.Push(force);
        trajectory.Hide();
    }
    
}
