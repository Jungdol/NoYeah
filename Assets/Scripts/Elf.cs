using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour
{
    public GameManager gameManager;
    private void OnMouseUp()
    {
        gameManager.elf += 1;
        gameManager.iself = false;
        Destroy(this.gameObject);
    }
    private void OnMouseEnter()
    {
        gameManager.iself = true;
    }
    private void OnMouseExit()
    {
        gameManager.iself = false;
    }
}
