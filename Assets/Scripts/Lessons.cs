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

        _spriteRenderer = _characterView.SpriteRenderer;
        _spriteAnimator.StartAnimation(_spriteRenderer, Track.run, true, 20);

        _paralaxManager = new ParalaxManager(_camera.transform, _backGround);
    }

    private void Update()
    {
        //Место обновления всех логических объектов.
        _spriteAnimator.Update();
        _paralaxManager.Update();

        if (Input.GetKeyDown(KeyCode.D))
            _camera.transform.position = new Vector3(_camera.transform.position.x + 0.5f, _camera.transform.position.y, _camera.transform.position.z);

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
