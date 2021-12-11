using UnityEngine;
using Pathfinding;

public class FlyEnemyAI
{
    private Transform _target;
    private float speed = 200.0f;
    private float nextWayPointDistance = 3.0f;
    private Path _path;
    private int _currentWayPoint;
    private Seeker _seeker;
    private Rigidbody2D _rb;

    public FlyEnemyAI(Transform target, Seeker seeker, Rigidbody2D rb)
    {
        _seeker = seeker;
        _rb = rb;
        _target = target;
    }

    public void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWayPoint = 0;
        }
    }

    public void FixedUpdate()
    {
        if (_path == null)
            return;

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWayPoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;
        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWayPoint]);

        if(distance < nextWayPointDistance)
        {
            _currentWayPoint++;
        }
    }
}
