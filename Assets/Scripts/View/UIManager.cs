using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("ハントモード時のエフェクト")]
    ParticleSystem _huntEffect;

    [SerializeField]
    [Header("死亡時の演出")]
    GameObject _deadPanel;
}
