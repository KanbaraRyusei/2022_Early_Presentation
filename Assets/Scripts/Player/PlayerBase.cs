using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class PlayerBase : MonoBehaviour
{
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

    Rigidbody2D _rb;
    List<ItemBase> _items = new List<ItemBase>();
    float _dashTime = 0f;
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
        //if(Input.GetButtonDown(""))
        //{
        //    Item();
        //}
        //if(Input.GetButtonDown(""))
        //{
        //    HaveItemChange();
        //}
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
            Debug.Log("aaa");
            _dashTime = 0f;
            await Task.Delay(_dashCoolTime);
            _canDash = true;
            Debug.Log("bbb");
        }
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(x, y).normalized * _dashSpeed;
    }
}
