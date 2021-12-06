using System.Collections.Generic;
using UnityEngine;

public class BulletsEmitter
{
    private const float _delay = 2;
    private const float _startSpeed = 10;

    private List<PhysicsBullet> _bullets = new List<PhysicsBullet>();
    private Transform _transform;

    private int _currentIndex;
    private float _timeTillNextBullet;

    public BulletsEmitter(List<BulletView> bulletViews, Transform transform)
    {
        _transform = transform;
        foreach (var bulletView in bulletViews)
        {
            _bullets.Add(new PhysicsBullet(bulletView));
        }
    }

    public void Update()
    {
        if (_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            _timeTillNextBullet = _delay;
            _bullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
            _currentIndex++;
            if (_currentIndex >= _bullets.Count) _currentIndex = 0;
        }
    }
}
