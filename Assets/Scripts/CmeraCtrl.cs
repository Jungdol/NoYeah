using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmeraCtrl : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -10);

    }
}
