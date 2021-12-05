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
    private MainHeroWalker _mainHeroWalker;
    [SerializeField]
    private Transform _muzzleTransform;
    [SerializeField]
    private System.Collections.Generic.List<BulletView> _bullets;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;
    //������ �� ���������� �������, ������� �� ��������, ����� ����� ������������:
    //��������, �������� �������� ��� �������� ����������, ���� ������ �� ����������� �������.
    private SpriteAnimator _spriteAnimator;
    private ParalaxManager _paralaxManager;

    private void Start()
    {
        SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfg");
        //����� �������� ��������.

        _spriteAnimator = new SpriteAnimator(config);
        //����� �������� � ���������� ���������� ��������, ����� ������ �������.

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);

        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);

        _aimingMuzzle = new AimingMuzzle(_muzzleTransform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _muzzleTransform);
    }

    private void Update()
    {
        //����� ���������� ���� ���������� ��������.
        _spriteAnimator.Update();
        _paralaxManager.Update();
        _mainHeroWalker.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {
        //����� ���������� ���� ���������� ��������, ����������� � ������.
    }

    private void OnDestroy()
    {
        //����� ���������� (������ ���������� ������� �� �������) �� ���� ���������� ��������.
    }

}
