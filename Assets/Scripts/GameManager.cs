using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Trajectory trajectory;
    public Fade pauseFade;
    public int elf;
    public bool iself=false;
    public Text elfcnt;
    public Image blacksanta;
    public float colltime;
    public bool isbalcksansta=false;
    public int ChangeCnt;
    [SerializeField] float pushForce = 4f;

    Camera cam;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;

    bool isDragging = false;
    float distance;

    public static GameManager Instance;
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
        colltime = 0.5f;
        pushForce = 3.0f;
    }

    private void Update()
    {
        elfcnt.text = "≥≠¿Ô¿Ã:" + elf;
        colltime -= Time.deltaTime;
        if (elf == 10)
        {
            pushForce=2.6f;
        }
        if (elf == 20)
        {
            pushForce = 2.4f;
        }
        if (elf == 30)
        {
            pushForce = 2.2f;
        }

        if (!iself && !EventSystem.current.IsPointerOverGameObject())
        {
            if (isbalcksansta == true)
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
                if (ball.junmpcnt == 2)
                {
                    isbalcksansta = false;
                }
            }
            if (colltime <= 0)
            {
                    if (ball.junmpcnt < 1)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            isDragging = true;
                            OnDragStart();                      
                        }
                    if (ball.time >= 0.25f)
                    {
                        if (Input.GetMouseButtonUp(0))
                        {
                            ball.junmpcnt += 1;
                            isDragging = false;
                            OnDragEnd();
                            colltime = 0.2f;
                        }
                    }
                        if (isDragging)
                        {
                            OnDrag();
                        }
                    }
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
    
    public void PauseBtn()
    {
        StartCoroutine(pauseFade.FadeOut("Game", 0.75f));
    }

    public void UnPauseBtn()
    {
        StartCoroutine(pauseFade.FadeIn("Game"));
    }

    public void OnBlackSanta()
    {
        if (!isbalcksansta&&elf>=2)
        {
            StartCoroutine(CoolTime(5f));
            Invoke("offsnata", 4.0f);
            elf -= 2;
            ChangeCnt += 1;

        }
    }

    IEnumerator CoolTime(float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            blacksanta.fillAmount = (1.0f / cool);
            isbalcksansta = true;
            yield return new WaitForFixedUpdate();
          
        }
    }
    public void offsnata()
    {
        isbalcksansta = false;
    }
}
