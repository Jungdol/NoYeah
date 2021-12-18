using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject setting;
    public string buttonSound;

    AudioManager theAudio;

    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android) // ����� �÷����� ��
        {
            if (Input.GetKey(KeyCode.Escape)) // �ڷΰ��� ��ư
                ExitBtn();
        }
    }

    public void StartBtn()
    {
        theAudio.Play(buttonSound);
        SceneManager.LoadScene("MainScene");
    }

    public void ExitBtn()
    {
        theAudio.Play(buttonSound);
        Application.Quit();
    }

    public void SettingBtn()
    {
        theAudio.Play(buttonSound);
        setting.SetActive(true);
    }

    public void BackSettingBtn()
    {
        theAudio.Play(buttonSound);
        setting.SetActive(false);
    }
}
