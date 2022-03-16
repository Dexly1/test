using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    float dirX, dirY;
    public float _Speed;
    public Rigidbody2D _rb;
    public SpriteRenderer _playerSprite;
    public Sprite[] _Sprites;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        dirY = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Debug.Log($"{dirX}, {dirY}");
        Vector3 movement = new Vector3(dirX, dirY, 0).normalized * _Speed;
        Debug.Log(movement);
        _rb.velocity = new Vector2(movement.x, movement.y);
        SpriteDirection();
    }

    public void SpriteDirection()
    {
        if (Mathf.Abs(dirX) > Mathf.Abs(dirY) && dirX > 0)
            _playerSprite.sprite = _Sprites[0]; //right
        if (Mathf.Abs(dirX) > Mathf.Abs(dirY) && dirX < 0)
            _playerSprite.sprite = _Sprites[1]; //left
        if (Mathf.Abs(dirX) < Mathf.Abs(dirY) && dirY > 0)
            _playerSprite.sprite = _Sprites[2]; //up
        if (Mathf.Abs(dirX) < Mathf.Abs(dirY) && dirY < 0)
            _playerSprite.sprite = _Sprites[3]; //down

    }
}
