using System;
using UnityEngine;

public class GameSyestemManager : MonoBehaviour
{
    /// <summary>�|�[�Y��ʂ��J�����ɌĂ΂�郁�\�b�h</summary>
    public event Action GamePause;
    GameText _gameText;
    PlayerController _playerController;
    readonly public int[] _cropsCount = new int[3]; //���n�����앨���J�E���g
    readonly public int[] _seedCount = new int[3]; //�����Ă����̐����J�E���g
    private void Awake()
    {
        _playerController = GameObject.FindAnyObjectByType<PlayerController>();
        _gameText = GameObject.FindAnyObjectByType<GameText>();
        for (int i = 0; i < _seedCount.Length; i++)
        {
            _seedCount[i] += 2;//�ϐ��ɐ�������
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();//�Q�[���𒆒f����
        }
    }

    /// <summary>
    /// ����1�ɂ͎�� ����2�ɂ͓n��������
    /// </summary>
    public void AddCropsCount(int num,int count)
    {
        _cropsCount[num] += count;//�O������l���󂯎�����Ƃ��ɕϐ��̒��ɓ����
    }
    /// <summary>
    /// ����1�ɂ͎�� ����2�ɂ͓n��������
    /// </summary>

    public void AddSeedCount(int num,int count)
    {
        _seedCount[num] += count;//�O������l���󂯎�����Ƃ��ɕϐ��̒��ɓ����
        _gameText.LoadSeedText();//�e�L�X�g���X�V����
    }
}
