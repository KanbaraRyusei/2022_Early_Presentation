using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class PlayerBase : MonoBehaviour
{
    public float Speed => _speed;
    public float DashSpeed => _dashSpeed;
    public int Sanity => _sanity;


    [SerializeField]
    [Header("スピード")]
    float _speed;

    [SerializeField]
    [Header("ダッシュスピード")]
    float _dashSpeed;

    [SerializeField]
    [Header("連続でダッシュできる時間")]
    float _continueDashTime;

    [SerializeField]
    [Header("ダッシュのクールタイム")]
    int _dashCoolTime;

    [SerializeField]
    [Header("正気度")]
    int _sanity;

    [SerializeField]
    [Header("正気度が減る時間")]
    float _santyDecreaseTime;

    Rigidbody2D _rb;
    List<ItemBase> _items = new List<ItemBase>();
    float _dashTime = 0f;
    float _brightPlaceTimer = 0f;
    float _darkPlaceTimer = 0f;
    bool _canDash = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetButton("Fire3") && _canDash)
        {
            Dash();
        }
        else
        {
            Move();
        }
        if (Input.GetKey(KeyCode.E))
        {
            Item();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            HaveItemChange();
        }
        SanityUpdate();
    }

    void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(x, y).normalized * _speed;
    }

    void Item()
    {
        if (_items[0].TryGetComponent(out IUseItem iu))
        {
            iu.UseItem();
        }
        else
        {
            Debug.Log("アイテムを持っていません");
        }
    }

    void HaveItemChange()
    {
        if(_items.Count > 1)
        {
            var haveItem = _items[0];
            _items[0] = _items[1];
            if(_items.Count > 2)
            {
                _items[1] = _items[2];
                _items[2] = haveItem;
            }
            else
            {
                _items[1] = haveItem;
            }
        }
    }

    async void Dash()
    {
        _dashTime += Time.deltaTime;
        if(_dashTime > _continueDashTime)
        {
            _canDash = false;
        }
        if(!_canDash)
        {
            _dashTime = 0f;
            await Task.Delay(_dashCoolTime);
            _canDash = true;
        }
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(x, y).normalized * _dashSpeed;
    }

    void SanityUpdate()
    {
        if (GameManager.Instance.OpenDoor) return;
        if(RoomManager.Instance.IsLight)
        {
            _brightPlaceTimer += Time.deltaTime;
        }
        else
        {
            _darkPlaceTimer += Time.deltaTime;
        }
        if(_brightPlaceTimer + _darkPlaceTimer > _santyDecreaseTime)
        {
            SanityDecrease(1);
        }
    }

    public void SanityDecrease(int num)
    {
        _sanity -= num;
    }
}
