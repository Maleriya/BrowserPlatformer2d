using UnityEngine;

public class Lessons : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    //Ссылки на объекты (инстансы префабов), находящиеся на сцене, ссылки видны в инспекторе (т. к. помечены SerializeField)
    //и туда можно будет закинуть визуальный объект из сцены, например, камеру, фон или персонажа.
    //Ссылки на объекты на сцене нужны, когда мы не хотим грузить префабы из ресурсов.
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
    //Ссылки на логические объекты, которые мы кешируем, чтобы потом использовать:
    //например, менеджер анимаций или менеджер параллакса, плюс ссылки на загруженные ресурсы.
    private SpriteAnimator _spriteAnimator;
    private ParalaxManager _paralaxManager;

    private void Start()
    {
        SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfg");
        //Место загрузки ресурсов.

        _spriteAnimator = new SpriteAnimator(config);
        //Место создания и связывания логических объектов, точка сборки проекта.

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);

        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);

        _aimingMuzzle = new AimingMuzzle(_muzzleTransform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _muzzleTransform);
    }

    private void Update()
    {
        //Место обновления всех логических объектов.
        _spriteAnimator.Update();
        _paralaxManager.Update();
        _mainHeroWalker.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {
        //Место обновления всех логических объектов, относящихся к физике.
    }

    private void OnDestroy()
    {
        //Место избавления (внутри происходит отписка от событий) от всех логических объектов.
    }

}
