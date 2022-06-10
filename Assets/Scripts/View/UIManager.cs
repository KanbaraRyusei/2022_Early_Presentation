using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("�n���g���[�h���̃G�t�F�N�g")]
    ParticleSystem _huntEffect;

    [SerializeField]
    [Header("���S���̉��o")]
    GameObject _deadPanel;
}
