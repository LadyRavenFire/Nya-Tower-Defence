using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;
    private Transform _target;
    private int _wavePointIndex = 0;

    void Start()
    {
        _target = WayPoints.Waypoints[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint(); 
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= WayPoints.Waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _wavePointIndex++;
        _target = WayPoints.Waypoints[_wavePointIndex];
    }
}
