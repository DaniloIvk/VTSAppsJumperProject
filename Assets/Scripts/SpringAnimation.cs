using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnimation : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _player = collision.gameObject;
        Rigidbody2D _playerRB = _player.GetComponent<Rigidbody2D>();
        if (_player.CompareTag("Player") && _playerRB.velocity.y <= 0)
            _anim.Play("SpringAnimation");
    }
}
