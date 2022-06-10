using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class GhostBase : MonoBehaviour
{
    public int Speed => _speed;
    public bool IsHunt => _isHunt;
    public bool IsSawPlayer => _isSawPlayer;

    [SerializeField]
    [Header("スピード")]
    int _speed;

    [SerializeField]
    [Header("ハントの時間")]
    int _huntTime;

    [SerializeField]
    [Header("視界のコライダー")]
    GameObject _visibilityCol;

    [SerializeField]
    [Header("徘徊するポイント")]
    GameObject[] _wanderingPoints;

    [SerializeField]
    [Header("証拠")]
    string[] _evidence;

    bool _isHunt = false;
    bool _isSawPlayer = false;
    Vector2 _playerPosition;

    private void Update()
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
        
    public async void StartHuntMode()
    {
        _isHunt = true;
        await Task.Delay(_huntTime);
        _isHunt = false;
    }

    private void Wandering()
    {

    }

    private void HuntMode()
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

    private void Hunting()
    {

    }

    public void FoundPlayer(PlayerBase player)
    {
        _isSawPlayer = true;
        _playerPosition = player.gameObject.transform.position;
    }
}
