using System;
using UnityEngine;

public class GameSyestemManager : MonoBehaviour
{
    /// <summary>ポーズ画面を開く時に呼ばれるメソッド</summary>
    public event Action GamePause;
    GameText _gameText;
    PlayerController _playerController;
    readonly public int[] _cropsCount = new int[3]; //収穫した作物をカウント
    readonly public int[] _seedCount = new int[3]; //持っている種の数をカウント
    private void Awake()
    {
        _playerController = GameObject.FindAnyObjectByType<PlayerController>();
        _gameText = GameObject.FindAnyObjectByType<GameText>();
        for (int i = 0; i < _seedCount.Length; i++)
        {
            _seedCount[i] += 2;//変数に数を入れる
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();//ゲームを中断する
        }
    }

    /// <summary>
    /// 引数1には種類 引数2には渡したい数
    /// </summary>
    public void AddCropsCount(int num,int count)
    {
        _cropsCount[num] += count;//外部から値を受け取ったときに変数の中に入れる
    }
    /// <summary>
    /// 引数1には種類 引数2には渡したい数
    /// </summary>

    public void AddSeedCount(int num,int count)
    {
        _seedCount[num] += count;//外部から値を受け取ったときに変数の中に入れる
        _gameText.LoadSeedText();//テキストを更新する
    }
}
