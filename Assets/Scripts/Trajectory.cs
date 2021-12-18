using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;
    Transform[] dotList;
    Vector2 pos;
    float timeStamp;
    private void Start()
    {
        Hide();
        PrepareDots();
    }
    void PrepareDots()
    {
        dotList = new Transform[dotsNumber];
        for (int i = 0; i < dotsNumber; i++)
        {
            dotList[i] = Instantiate(dotPrefab, null).transform;
            dotList[i].parent = dotsParent.transform;
        }
    }
    public void UpdateDots(Vector3 ballpos,Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for(int i=0;i<dotsNumber; i++)
        {
            pos.x = (ballpos.x + forceApplied.x * timeStamp);
            pos.y = (ballpos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;
            dotList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }
    public void Show()
    {
        dotsParent.SetActive(true);    
    }
    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
