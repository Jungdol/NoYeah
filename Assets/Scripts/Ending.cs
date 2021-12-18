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
    public GameObject Sucess;
    public GameObject Fail;
    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);
        Sucess.SetActive(false);
        Fail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scored = gameManager.elf * 375;
        elfCount.text =""+gameManager.elf;
        change.text = "" + gameManager.ChangeCnt;
        score.text = "" + scored ;
        if (scored<6000)
        {
            Rank.text = "D";
            Sucess.SetActive(false);
            Fail.SetActive(true);

        }
        else if (6000 <= scored && scored < 7000)
        {
            Rank.text = "c";
            Sucess.SetActive(false);
            Fail.SetActive(true);
        }
        else if (7000 <= scored && scored < 8000)
        {
            Rank.text = "B";
            Sucess.SetActive(true);
            Fail.SetActive(false);
        }
        else if (8000 <= scored && scored < 9000)
        {
            Rank.text = "A";
            Sucess.SetActive(true);
            Fail.SetActive(false);
        }
        else if (9000 <= scored && scored < 10000)
        {
            Rank.text = "S";
            Sucess.SetActive(true);
            Fail.SetActive(false);
        }
        else if (10000 <= scored )
        {
            Rank.text = "S+";
            Sucess.SetActive(true);
            Fail.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            end.SetActive(true);
        }
    }
}
