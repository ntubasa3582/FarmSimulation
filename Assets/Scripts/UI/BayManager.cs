using UnityEngine;

public class BayManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    void PressButton()
    {

    }
}
