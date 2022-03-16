using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceSys : MonoBehaviour
{
    static public InterfaceSys single;
    public int _countEnemies;
    public int _countNeutralizedEnemies;
    public TextMeshProUGUI _textCountEnemies;
    public TextMeshProUGUI _textGameResult;
    public GameObject _restartPanel;
    public GameObject _pointJoystick;
    private void Awake()
    {
        single = this;
    }

    void Start()
    {
        UpdateCount();
    }

    public void UpdateCount()
    {
        _textCountEnemies.text = "�������: " + _countNeutralizedEnemies + "/" + _countEnemies.ToString();
        if (_countNeutralizedEnemies == _countEnemies)
        {
            _textGameResult.text = "������\n�� �������� ���� ��������";
            _restartPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Lose(bool bombOrFerm)
    {
        if (bombOrFerm)
            _textGameResult.text = "���������\n������ ������ ������";
        else
            _textGameResult.text = "���������\n������ ������ ������";

        _restartPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
