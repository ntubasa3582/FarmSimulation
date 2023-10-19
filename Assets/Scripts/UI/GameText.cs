using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameText : MonoBehaviour
{
    [SerializeField] List<Text> _gameTexts = new();
    PlayerController _playerController;
    GameSyestemManager _gameSyestemManager;
    DayCounter _dayCounter;
    public enum TextName
    {
        /// <summary>���ɂ� </summary>
        DayText,
        /// <summary>���n������</summary>
        FruitsText,
        /// <summary>��1</summary>
        SeedText1,
        /// <summary>��2</summary>
        SeedText2,
        /// <summary>��3</summary>
        SeedText3,
    }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController = GameObject.FindObjectOfType<PlayerController>();
        _gameSyestemManager = GetComponent<GameSyestemManager>();
        _dayCounter = GetComponent<DayCounter>();
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        //Debug.Log(_gameTexts[(int)TextName.DayCount].text);
    }
    private void OnEnable()
    {
        _dayCounter.DayChange += LoadDayText;//�f���Q�[�g�o�^
        _playerController.SeedCount += LoadSeedText;
        _playerController.FruitsCount += LoadCropsText;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= LoadDayText;//�f���Q�[�g�o�^������
        _playerController.SeedCount -= LoadSeedText;
        _playerController.FruitsCount -= LoadCropsText;
    }

    private void LoadDayText()//�Ă΂ꂽ��e�L�X�g���X�V����
    {
        //_dayCount�̒l���e�L�X�g�ŕ\�����Ă���
        //_gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0" + "����");
    }

    public void LoadSeedText()//�Ă΂ꂽ��e�L�X�g���X�V����
    {
        //_plantCount�̒l���e�L�X�g�ŕ\�����Ă���
        _gameTexts[(int)TextName.SeedText1].text = _gameSyestemManager._seedCount[0].ToString("�c��" + "0" + "��");
        _gameTexts[(int)TextName.SeedText2].text = _gameSyestemManager._seedCount[1].ToString("�c��" + "0" + "��");
        _gameTexts[(int)TextName.SeedText3].text = _gameSyestemManager._seedCount[2].ToString("�c��" + "0" + "��");
    }
    private void LoadCropsText()//�Ă΂ꂽ��e�L�X�g���X�V����
    {
        //���n���������e�L�X�g�ŕ\�����Ă���
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[0].ToString("0" + "���n");
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[1].ToString("0" + "���n");
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[2].ToString("0" + "���n");
    }
}
