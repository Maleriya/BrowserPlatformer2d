using System.Collections.Generic;
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
    //Ссылки на логические объекты, которые мы кешируем, чтобы потом использовать:
    //например, менеджер анимаций или менеджер параллакса, плюс ссылки на загруженные ресурсы.
    private SpriteAnimator _spriteAnimatorPlayer;
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimatorCoins;
    private CoinsManager _coinsManager;
    private LevelCompleteManager _levelCompleteManager;

    private void Start()
    {
        SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfg");
        SpriteAnimationsConfig configCoin = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsCnfgCoin");
        //Место загрузки ресурсов.

        _spriteAnimatorPlayer = new SpriteAnimator(config);
        _spriteAnimatorCoins = new SpriteAnimator(configCoin);
        //Место создания и связывания логических объектов, точка сборки проекта.

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);

        _mainHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimatorPlayer);

        _aimingMuzzle = new AimingMuzzle(_muzzleTransform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _muzzleEmitterTransform);

        _coinsManager = new CoinsManager(_characterView, _coins, _spriteAnimatorCoins);
        _levelCompleteManager = new LevelCompleteManager(_characterView, _deathZones, null);
    }

    private void Update()
    {
        //Место обновления всех логических объектов.
        _spriteAnimatorPlayer.Update();
        _paralaxManager.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
        _spriteAnimatorCoins.Update();
    }

    private void FixedUpdate()
    {
        //Место обновления всех логических объектов, относящихся к физике.
        _mainHeroWalker.FixedUpdate();
    }

    private void OnDestroy()
    {
        //Место избавления (внутри происходит отписка от событий) от всех логических объектов.
    }

}
