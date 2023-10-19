using UnityEngine;

public class BaySeed : MonoBehaviour
{
    PlayerController _playerController;

    private void Awake()
    {
        _playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }


    void SeedBay1()
    {

    }

    void SeedBayAll()
    {

    }
}
