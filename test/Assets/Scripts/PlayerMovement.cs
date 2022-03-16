using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float dirX, dirY;
    public float _Speed;
    public Rigidbody2D _rb;
    public SpriteRenderer _playerSprite;
    public Sprite[] _Sprites;
    public FixedJoystick fixedJoystick;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = fixedJoystick.Horizontal;
        dirY = fixedJoystick.Vertical;
        Vector3 movement = new Vector3(dirX, dirY, 0).normalized * _Speed;
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
