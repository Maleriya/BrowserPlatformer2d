using UnityEngine;

public class CameraFollow
{

    private Transform _target;
    private Transform _camera;

    public CameraFollow(Transform camera, Transform target)
    {
        _target = target;
        _camera = camera;
    }

    public void LateUpdate()
    {
        _camera.position = new Vector3(_target.position.x, _camera.position.y, _camera.position.z);
    }
}