using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    [SerializeField] GameObject[] _target;
    float _moveSpeed = 3f;
    bool _startMoveCheck = false;

    private void Awake()
    {
        Move();
    }

    void StartNPC()
    {
        _startMoveCheck=true;
    }

    void Move()
    {
        while (_startMoveCheck)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target[0].transform.position, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target")
        {
            _startMoveCheck = false;
        }
    }
}
