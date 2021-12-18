using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    public GameObject end;
    public int scored;
    public Text elfCount;
    public Text change;
    public Text score;
    public Text Rank;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scored = gameManager.elf * 1000;
        elfCount.text =""+gameManager.elf;
        change.text = "" + gameManager.ChangeCnt;
        score.text = "" + scored ;
        if (5000 <= scored&&scored<6000)
        {
            Rank.text = "D";
        }
        else if (6000 <= scored && scored < 7000)
        {
            Rank.text = "c";
        }
        else if (7000 <= scored && scored < 8000)
        {
            Rank.text = "B";
        }
        else if (8000 <= scored && scored < 9000)
        {
            Rank.text = "A";
        }
        else if (9000 <= scored && scored < 10000)
        {
            Rank.text = "S";
        }
        else if (10000 <= scored )
        {
            Rank.text = "S+";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            end.SetActive(true);
        }
    }
}
