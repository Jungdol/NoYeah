using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject setting;

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) // 모바일 플랫폼일 때
        {
            if (Input.GetKey(KeyCode.Escape)) // 뒤로가기 버튼
                ExitBtn();
        }
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void SettingBtn()
    {
        setting.SetActive(true);
    }

    public void BackSettingBtn()
    {
        setting.SetActive(false);
    }
}
