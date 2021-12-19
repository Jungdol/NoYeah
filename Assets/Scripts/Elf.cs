using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour
{
    AudioManager theAudio;
    public GameManager gameManager;
    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
    }
    private void OnMouseUp()
    {
        theAudio.Play("AddElf");
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
