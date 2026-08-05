using System.Collections; // Added for Coroutines
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string _horizontalInput = "Horizontal", _verticalInput = "Vertical";

    [SerializeField] private Rigidbody2D _rb2d;

    private Vector2 _input;

    [SerializeField] private float _speed = 2f;


    public Timer timerScript;

    

    // --- ADDED FIELDS FOR CORE MECHANICS ---
    private Vector3 _startPosition;
    private bool _isDead = false;
    [SerializeField] private float _delayBeforeReset = 0.5f;

    // --- ADDED FIELDS FOR SPRITE VISUALS ---
    [Header("Sprite Setup")]
    [SerializeField] private SpriteRenderer _spriteRenderer; // References the SpriteRenderer component
    [SerializeField] private Sprite _faceRightSprite;       // The image when moving right
    [SerializeField] private Sprite _faceLeftSprite;        // The image when moving left


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Save the starting position when the game begins
        _startPosition = transform.position;

        // Auto-get the SpriteRenderer if not manually assigned in Inspector
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Don't take input if the player has hit an obstacle or finished
        if (_isDead) return;

        float horizontalInput = Input.GetAxisRaw(_horizontalInput);
        float verticalInput = Input.GetAxisRaw(_verticalInput);
        _input = new Vector2(horizontalInput, verticalInput);
        _input.Normalize();

        // --- ADDED: HANDLE FACING DIRECTION VISUALS ---
        HandleFacingDirection(horizontalInput);

        
    }

    private void FixedUpdate()
    {
        // Stop moving if dead or resetting
        if (_isDead) return;

        Vector2 targetPosition = _rb2d.position + _input * _speed * Time.fixedDeltaTime;
        _rb2d.MovePosition(targetPosition);
    }

    // --- ADDED: NEW METHOD TO SWAP SPRITES BASED ON INPUT ---
    void HandleFacingDirection(float horizontalInput)
    {
        // If moving right (input is positive)
        if (horizontalInput > 0.1f)
        {
            if (_faceRightSprite != null)
            {
                _spriteRenderer.sprite = _faceRightSprite;
            }
        }
        // If moving left (input is negative)
        else if (horizontalInput < -0.1f)
        {
            if (_faceLeftSprite != null)
            {
                _spriteRenderer.sprite = _faceLeftSprite;
            }
        }
        // If horizontal input is 0 (idle), we don't change the sprite, keeping the last direction.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("obstacle"))
        {
            timerScript.StopTimer();
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            LevelCompleted();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("obstacle"))
        {
            timerScript.StopTimer();
            GameOver();
        }
        else if (other.CompareTag("Finish"))
        {
            LevelCompleted();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        // Prevent multiple collision calls
        if (_isDead) return;
        _isDead = true;

        // Reset input vector
        _input = Vector2.zero;

        // Stop physics immediately on impact
        if (_rb2d != null)
        {
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.angularVelocity = 0f;
            _rb2d.bodyType = RigidbodyType2D.Kinematic;
        }

        // Start reset routine
        StartCoroutine(ResetPlayerRoutine());
    }

    void LevelCompleted()
    {
        Debug.Log("Goal Reached!");

        if (_isDead) return;
        _isDead = true;

        _input = Vector2.zero;

        if (_rb2d != null)
        {
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.angularVelocity = 0f;
            _rb2d.bodyType = RigidbodyType2D.Kinematic;
        }

        // Save best time on complete
        if (timerScript != null)
        {
            timerScript.CompleteLevel();
        }

        StartCoroutine(ResetPlayerRoutine());
    }

    // --- RESET ROUTINE ---
    IEnumerator ResetPlayerRoutine()
    {
        yield return new WaitForSeconds(_delayBeforeReset);

        // Teleport back to original position
        transform.position = _startPosition;

        // --- ADDED: RESET SPRITE TO DEFAULT ON RESPAWN ---
        // Assuming your initial face direction is Right
        if (_spriteRenderer != null && _faceRightSprite != null)
        {
            _spriteRenderer.sprite = _faceRightSprite;
        }

        // Restart the timer when player resets
        if (timerScript != null)
        {
            timerScript.ResetTimer();
        }

        // Restore physics & allow player control again
        if (_rb2d != null)
        {
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.bodyType = RigidbodyType2D.Dynamic;
        }

        _isDead = false;
    }

}