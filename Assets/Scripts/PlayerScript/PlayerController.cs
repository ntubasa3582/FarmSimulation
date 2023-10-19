using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _gameManagerObject;
    [SerializeField] float _moveSpeed = 3;//�v���C���[�̃X�s�[�h
    [SerializeField] GameObject[] _seedObjecct;//��������I�u�W�F�N�g
    //���̃��\�b�h���Ă΂ꂽ�Ƃ��ɐ����̃I�u�W�F�N�g�̐����L�^���Ă���e�L�X�g�̒l��ς���
    public event Action SeedCount; 
    public event Action FruitsCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    GameSyestemManager _syestemManager;
    bool _isGround = false;//�n�ʂ̃`�F�b�N
    float _clickTime = 1;//�N���b�N�ł��Ȃ��悤�ɃC���^�[�o�������Ă���
    int[] _holder = new int[3]; //�擾�����l��ۊǂ��Ă����ϐ�

    public enum SeedName
    {
        Red,
        Green,
        Blue,
        yellow,
    }

    void Start()
    {
        SeedCount();
        FruitsCount();
        Physics.gravity = new Vector3(0, -30, 0);
        _rigidbody = GetComponent<Rigidbody>();
        _syestemManager = FindFirstObjectByType<GameSyestemManager>();
    }

    void Update()
    {
        _position = new Vector3(transform.position.x, 0.94f, transform.position.z);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // �ړ��̓��͂��Ȃ����͉�]�����Ȃ��B���͂����鎞�͂��̕����ɃL�����N�^�[��������B
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rigidbody.velocity = dir.normalized * _moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 2f, 0);
        }
        if (Input.GetMouseButton(0))
        {
            _clickTime += Time.deltaTime;
            if (_clickTime > 1)//�A���ŃN���b�N�o���Ȃ��悤�ɃC���^�[�o�������Ă�
            {
                _clickTime = 0;
                PlantObject();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�G��Ă���I�u�W�F�N�g����Ground�^�O�t���Ă��邩���`�F�b�N����
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruits1")
        {
            _syestemManager.AddCropsCount(0,1);
            FruitsCount();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Fruits2")
        {
            _syestemManager.AddCropsCount(1, 1);
            FruitsCount();
            Destroy(other.gameObject);
        }
        else if ((other.gameObject.tag == "Fruits3"))
        {
            _syestemManager.AddCropsCount(2, 1);
            FruitsCount();
            Destroy(other.gameObject);
        }
    }

    void PlantObject()
    {
        if (_isGround == true)
        {
            //_plantCount��0����̒l�Ȃ�I�u�W�F�N�g�𐶐����ăJ�E���g��1���炷
            if (_syestemManager._seedCount[0] > 0)
            {
                InstanceObject(0);
            }
            else if (_syestemManager._seedCount[1] > 0)
            {
                InstanceObject(1);
            }
            else if (_syestemManager._seedCount[2] > 0)
            {
                InstanceObject(2);
            }
        }

    }

    void InstanceObject(int num)
    {
        Instantiate(_seedObjecct[num], _position, Quaternion.identity);//�I�u�W�F�N�g�𐶐�����
        _syestemManager.AddSeedCount(num, -1);//��𐶐�������Q�[���}�l�[�W���[�̃��\�b�h�Ƀ}�C�i�X��n���Ă���
    }
}
