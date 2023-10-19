using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _gameManagerObject;
    [SerializeField] float _moveSpeed = 3;//プレイヤーのスピード
    [SerializeField] GameObject[] _seedObjecct;//生成するオブジェクト
    //このメソッドが呼ばれたときに生成のオブジェクトの数を記録しているテキストの値を変える
    public event Action SeedCount; 
    public event Action FruitsCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    GameSyestemManager _syestemManager;
    bool _isGround = false;//地面のチェック
    float _clickTime = 1;//クリックできないようにインターバルをつけている
    int[] _holder = new int[3]; //取得した値を保管しておく変数

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
        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rigidbody.velocity = dir.normalized * _moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 2f, 0);
        }
        if (Input.GetMouseButton(0))
        {
            _clickTime += Time.deltaTime;
            if (_clickTime > 1)//連続でクリック出来ないようにインターバルをつけてる
            {
                _clickTime = 0;
                PlantObject();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //触れているオブジェクトがにGroundタグ付いているかをチェックする
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
            //_plantCountが0より上の値ならオブジェクトを生成してカウントを1減らす
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
        Instantiate(_seedObjecct[num], _position, Quaternion.identity);//オブジェクトを生成する
        _syestemManager.AddSeedCount(num, -1);//種を生成したらゲームマネージャーのメソッドにマイナスを渡している
    }
}
