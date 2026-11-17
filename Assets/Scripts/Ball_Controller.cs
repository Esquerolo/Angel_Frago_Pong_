using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballVelocity = 10f;
    float initialVelocity;
    public float velocityMulty = 1;
    public Game_Manager gameManager;

    AudioSource _audioSource;
    Rigidbody2D _rb;
    ParticleSystem _particleSystem;
    float _lastHorizontalDirection = 1f;

    public float timeAlive = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponent<ParticleSystem>();
        initialVelocity = ballVelocity;
        LaunchBall(0);
    }
    private void Update()
    {
        if (timeAlive > 2f && velocityMulty < 2f)
        {
            velocityMulty += 0.25f;
            ballVelocity *= velocityMulty;
            timeAlive = 0f;
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > ballVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * ballVelocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= ballVelocity * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 1f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * ballVelocity;
        }
    }

    void LaunchBall(int dir)
    {
        velocityMulty = 1f;
        timeAlive = 0f;
        ballVelocity = initialVelocity;
        this.transform.position = Vector2.zero;
        if (dir == 0)
        {
            _lastHorizontalDirection = Random.value > 0.5f ? 1f : -1f;
        }
        else
        {
            _lastHorizontalDirection = dir;
        }

        float yVelocity = Random.Range(-0.7f, 0.7f);

        _rb.velocity = new Vector2(
            _lastHorizontalDirection,
            yVelocity
        ).normalized * ballVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall_R"))
        {
            gameManager.puntosJugador1++;
            LaunchBall(-1);
            gameManager.UpdatePointsText();
        }
        if (collision.gameObject.CompareTag("Wall_L"))
        {
            gameManager.puntosJugador2++;
            LaunchBall(1);
            gameManager.UpdatePointsText();
        }
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.Play();
        _particleSystem.Play();
    }
}