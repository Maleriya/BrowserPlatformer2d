using UnityEngine;

public class MainHeroWalker
{
    private const float _walkSpeed = 3f;
    private const float _animationsSpeed = 10f;
    private const float _jumpStartSpeed = 8f;
    private const float _movingThresh = 0.1f;
    private const float _flyThresh = 1f;
    private const float _groundLevel = -2.5f;
    private const float _g = -10f;

    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);

    private float _yVelocity;
    private bool _doJump;
    private float _xAxisInput;

    private CharacterView _view;
    private SpriteAnimator _spriteAnimator;

    public MainHeroWalker(CharacterView view, SpriteAnimator spriteAnimator)
    {
        _view = view;
        _spriteAnimator = spriteAnimator;
        _spriteAnimator.StartAnimation(view.SpriteRenderer, Track.blink, true, 20);
    }

    public void Update()
    {
        _doJump = Input.GetAxis("Vertical") > 0;
        _xAxisInput = Input.GetAxis("Horizontal");
        var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

        if (IsGrounded())
        {
            //walking
            if (goSideWay) GoSideWay();
            _spriteAnimator.StartAnimation(_view.SpriteRenderer, goSideWay ? Track.run : Track.idle, true, _animationsSpeed);

            //start jump
            if (_doJump && _yVelocity == 0)
            {
                _yVelocity = _jumpStartSpeed;
            }
            //stop jump
            else if (_yVelocity < 0)
            {
                _yVelocity = 0;
                _view.Transform.position = _view.Transform.position.Change(y: _groundLevel);
            }
        }
        else
        {
            //flying
            if (goSideWay) GoSideWay();
            if (Mathf.Abs(_yVelocity) > _flyThresh)
            {
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, GetTrackForUpOrDown(), true, _animationsSpeed);
            }

            _yVelocity += _g * Time.deltaTime;
            _view.Transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
        }
    }

    private Track GetTrackForUpOrDown()
    {
        if (_yVelocity > 0)
            return Track.jumpUp;

        return Track.jumpDown;
    }

    private void GoSideWay()
    {
        _view.Transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
        _view.Transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
    }

    public bool IsGrounded()
    {
        return _view.Transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
    }
}
