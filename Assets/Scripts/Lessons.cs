using Pathfinding;
using Platformer.GenerateWorld;
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
    [SerializeField]
    private Seeker _seeker;
    [SerializeField]
    private LevelObjectView _flyEnemy;
    [SerializeField]
    private GenerateLevelView _generateLevelView;
  
    //Ссылки на логические объекты, которые мы кешируем, чтобы потом использовать:
    //например, менеджер анимаций или менеджер параллакса, плюс ссылки на загруженные ресурсы.
    private SpriteAnimator _spriteAnimatorPlayer;
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimatorCoins;
    private CoinsManager _coinsManager;
    private LevelCompleteManager _levelCompleteManager;
    private CameraFollow _cameraFollow;
    private FlyEnemyAI _flyEnemyAI;
    private GeneratorLevelController _generatorLevelController;
    

    private void Awake()
    {
        _generatorLevelController = new GeneratorLevelController(_generateLevelView);
        _generatorLevelController.Awake();
    }

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

        _cameraFollow = new CameraFollow(_camera.transform, _characterView.transform);

        _flyEnemyAI = new FlyEnemyAI(_characterView.transform, _seeker, _flyEnemy.Rigidbody2D);
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);    
    }

    void UpdatePath()
    {
        _flyEnemyAI.UpdatePath();
    }

    private void Update()
    {
        //Место обновления всех логических объектов.
        _spriteAnimatorPlayer.Update();
        _paralaxManager.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
        _spriteAnimatorCoins.Update();
        _generatorLevelController.Update(_generateLevelView);
    }

    private void FixedUpdate()
    {
        //Место обновления всех логических объектов, относящихся к физике.
        _mainHeroWalker.FixedUpdate();
        _flyEnemyAI.FixedUpdate();
    }

    private void LateUpdate()
    {
        _cameraFollow.LateUpdate();
    }

    private void OnDestroy()
    {
        //Место избавления (внутри происходит отписка от событий) от всех логических объектов.
    }

}
