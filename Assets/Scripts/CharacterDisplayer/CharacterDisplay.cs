using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField]
    private float _animationSpeed;
    [SerializeField]
    private Equipment _baseBody;
    [SerializeField]
    private PlayerMovement _playerMovement;
    [SerializeField]
    private SpriteRenderer _baseRenderer;
    [SerializeField]
    private SpriteRenderer _outfitRenderer;
    [SerializeField]
    private Outfit _outfit;

    private Face _characterFacing = Face.South;

    float _timer;
    int _frameIndex;
    bool idle = true;

    private void Update()
    {
        UpdateCharacterFacing();

        _timer += Time.deltaTime;

        if(_timer >= 1/_animationSpeed)
        {
            _timer = 0f;

            var index = _frameIndex;

            if (_frameIndex < 5)
            {
                _frameIndex++;
            }
            else
            {
                _frameIndex = 0;
            }
            _baseRenderer.sprite = GetNextFrame(_baseBody.sprites, index);
            _outfitRenderer.sprite = GetNextFrame(_outfit.sprites, index);
        }

    }

    Sprite GetNextFrame(Sprite[] frames, int index)
    {
        var mode = idle ? 0 : 4;

        mode += (int)_characterFacing;

        var frame = spriteIndex[mode, index];

        return frames[frame];
    }

    void UpdateCharacterFacing()
    {
        idle = _playerMovement.rigidbody2d.velocity == Vector2.zero;

        var velocity = _playerMovement.rigidbody2d.velocity;

        if(velocity.x < 0 || velocity.y < 0)
        {
            if(velocity.x < velocity.y)
            {
                _characterFacing = Face.West;
            }
            else
            {
                _characterFacing = Face.South;
            }
        }
        else if (velocity.x > 0 || velocity.y > 0)
        {
            if (velocity.x > velocity.y)
            {
                _characterFacing = Face.East;
            }
            else
            {
                _characterFacing = Face.North;
            }
        }
    }



    int[,] spriteIndex = new int[8,6]
    {
        {4, 5, 6, 7, 8, 9},       //idle east
        {10, 11, 12, 13, 14, 15}, //idle north
        {16, 17, 18, 19, 20, 21}, //idle west
        {22, 23, 24, 25, 26, 27}, //idle south
        {28, 29, 30, 31, 32, 33}, //walk east
        {34, 35, 36, 37, 38, 39}, //walk north
        {40, 41, 42, 43, 44, 45}, //walk west
        {46, 47, 48, 49, 50, 51}  //walk south
    };
        
    enum Face
    {
        East,
        North,
        West,
        South
    }
}
