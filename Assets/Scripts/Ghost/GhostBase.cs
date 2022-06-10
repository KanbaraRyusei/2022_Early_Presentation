using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class GhostBase : MonoBehaviour, IHunt
{
    public int Speed => _speed;
    public bool IsHunt => _isHunt;
    public bool IsSawPlayer => _isSawPlayer;

    [SerializeField]
    [Header("�X�s�[�h")]
    int _speed;

    [SerializeField]
    [Header("�n���g�̎���(�~���b)")]
    int _huntTime;

    [SerializeField]
    [Header("�p�j����|�C���g")]
    GameObject[] _wanderingPoints;

    [SerializeField]
    [Header("�؋�")]
    string[] _evidence;

    bool _isHunt = false;
    bool _isSawPlayer = false;
    Vector2 _playerPosition;

    void Update()
    {
        if(_isHunt)
        {
            HuntMode();
        }
        else
        {
            Wandering();
        }
    }
        
    async void StartHuntMode()
    {
        _isHunt = true;
        await Task.Delay(_huntTime);
        _isHunt = false;
    }

    void Wandering()
    {

    }

    void HuntMode()
    {
        if(_isSawPlayer)
        {
            Hunting();
        }
        else
        {
            Wandering();
        }
    }

    void Hunting()
    {

    }

    public void FoundPlayer(PlayerBase player)
    {
        _isSawPlayer = true;
        _playerPosition = player.gameObject.transform.position;
    }

    public void Hunt()
    {
        StartHuntMode();
    }
}
