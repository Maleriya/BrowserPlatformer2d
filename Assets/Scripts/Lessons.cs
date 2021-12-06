using System.Collections.Generic;
using UnityEngine;

public class Lessons : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    //������ �� ������� (�������� ��������), ����������� �� �����, ������ ����� � ���������� (�. �. �������� SerializeField)
    //� ���� ����� ����� �������� ���������� ������ �� �����, ��������, ������, ��� ��� ���������.
    //������ �� ������� �� ����� �����, ����� �� �� ����� ������� ������� �� ��������.
    [SerializeField]
    private Transform _backGround;
    [SerializeField]
    private CharacterView _characterView;
    private MainHeroPhysicsWalker _mainHeroWalker;
    [SerializeField]
    private Transform _muzzleTransform;
    [SerializeField]
    private Transform _muzzleEmitterTransform;
    [SerializeField]
    private List<BulletView> _bullets;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;   
    [SerializeField]
    private List<LevelObjectView> _coins;
    [SerializeField]
    private List<LevelObjectView> _deathZones;
    //������ �� ���������� �������, ������� �� ��������, ����� ����� ������������:
    //��������, �������� �������� ��� �������� ����������, ���� ������ �� ����������� �������.
    private SpriteAnimator _spriteAnimatorPlayer;
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimatorCoins;
    private CoinsManager _coinsManager;
    private LevelCompleteManager _levelCompleteManager;

    private void Start()
    {
        SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfg");
        SpriteAnimationsConfig configCoin = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfgCoin");
        //����� �������� ��������.

        _spriteAnimatorPlayer = new SpriteAnimator(config);
        _spriteAnimatorCoins = new SpriteAnimator(configCoin);
        //����� �������� � ���������� ���������� ��������, ����� ������ �������.

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);

        _mainHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimatorPlayer);

        _aimingMuzzle = new AimingMuzzle(_muzzleTransform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _muzzleEmitterTransform);

        _coinsManager = new CoinsManager(_characterView, _coins, _spriteAnimatorCoins);
        _levelCompleteManager = new LevelCompleteManager(_characterView, _deathZones, null);
    }

    private void Update()
    {
        //����� ���������� ���� ���������� ��������.
        _spriteAnimatorPlayer.Update();
        _paralaxManager.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
        _spriteAnimatorCoins.Update();
    }

    private void FixedUpdate()
    {
        //����� ���������� ���� ���������� ��������, ����������� � ������.
        _mainHeroWalker.FixedUpdate();
    }

    private void OnDestroy()
    {
        //����� ���������� (������ ���������� ������� �� �������) �� ���� ���������� ��������.
    }

}
