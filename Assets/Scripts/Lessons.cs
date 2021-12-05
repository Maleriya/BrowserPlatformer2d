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

        _spriteRenderer = _characterView.SpriteRenderer;
        _spriteAnimator.StartAnimation(_spriteRenderer, Track.run, true, 20);

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);
    }

    private void Update()
    {
        //����� ���������� ���� ���������� ��������.
        _spriteAnimator.Update();
        _paralaxManager.Update();

        if (Input.GetKeyDown(KeyCode.D))
            _camera.transform.position = new Vector3(_camera.transform.position.x + 0.5f, _camera.transform.position.y, _camera.transform.position.z);

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
