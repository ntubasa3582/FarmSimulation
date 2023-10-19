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
        /// <summary>日にち </summary>
        DayText,
        /// <summary>収穫した数</summary>
        FruitsText,
        /// <summary>種1</summary>
        SeedText1,
        /// <summary>種2</summary>
        SeedText2,
        /// <summary>種3</summary>
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
        _dayCounter.DayChange += LoadDayText;//デリゲート登録
        _playerController.SeedCount += LoadSeedText;
        _playerController.FruitsCount += LoadCropsText;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= LoadDayText;//デリゲート登録を解除
        _playerController.SeedCount -= LoadSeedText;
        _playerController.FruitsCount -= LoadCropsText;
    }

    private void LoadDayText()//呼ばれたらテキストを更新する
    {
        //_dayCountの値をテキストで表示している
        //_gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0" + "日目");
    }

    public void LoadSeedText()//呼ばれたらテキストを更新する
    {
        //_plantCountの値をテキストで表示している
        _gameTexts[(int)TextName.SeedText1].text = _gameSyestemManager._seedCount[0].ToString("残り" + "0" + "個");
        _gameTexts[(int)TextName.SeedText2].text = _gameSyestemManager._seedCount[1].ToString("残り" + "0" + "個");
        _gameTexts[(int)TextName.SeedText3].text = _gameSyestemManager._seedCount[2].ToString("残り" + "0" + "個");
    }
    private void LoadCropsText()//呼ばれたらテキストを更新する
    {
        //収穫した数をテキストで表示している
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[0].ToString("0" + "収穫");
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[1].ToString("0" + "収穫");
        //_gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount[2].ToString("0" + "収穫");
    }
}
