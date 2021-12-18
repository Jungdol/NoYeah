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
        if (Application.platform == RuntimePlatform.Android) // ����� �÷����� ��
        {
            if (Input.GetKey(KeyCode.Escape)) // �ڷΰ��� ��ư
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
