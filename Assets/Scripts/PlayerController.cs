using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator _anim;
    private AudioSource _audioSource;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _wrapPlayerRange = 0;

    [SerializeField]
    private AudioClip _jumpClip;

    [SerializeField]
    private AudioClip _collectCoinClip;

    private int _score = 0;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        _scoreText.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * _speed, rb.velocity.y);

        WrapPlayer();
    }

    void OnEnable()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", _score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && rb.velocity.y == 0)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rb.velocity.y <= 0)
            switch (collision.gameObject.tag)
            {
                case "Coin":
                    Destroy(collision.gameObject);
                    _score++;
                    _scoreText.text = _score.ToString();
                    _audioSource.PlayOneShot(_collectCoinClip, 1);
                    break;
                case "Spike":
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    _anim.Play("GameOver");
                    break;
            }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, 1 * _jumpForce));
        _anim.Play("JumpingAnimation");
        _audioSource.PlayOneShot(_jumpClip, 1);
    }

    private void WrapPlayer()
    {
        if (transform.position.x <= -_wrapPlayerRange)
            transform.position = new Vector2(_wrapPlayerRange - 0.5f, transform.position.y);

        if (transform.position.x >= _wrapPlayerRange)
            transform.position = new Vector2(-_wrapPlayerRange + 0.5f, transform.position.y);
    }

    public void GameOver()
    {
        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
        SceneManager.LoadScene("GameOverScene");
    }
}
