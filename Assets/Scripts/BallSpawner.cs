using Limits;
using MathOperations;
using ObjectPoolSystem;
using StatsManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private CameraGameBound cameraGameBound;

    [Space]
    [SerializeField] private LimitFloat timerLimit;
    [SerializeField] private LimitFloat scaleLimit;
    
    [Space] [Min(1)]
    [SerializeField] private float fallSpeedMultiplier = 1;

    private float _spawnTimer = 0f;

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer > 0) return;
        
        SpawnBall();
        
        _spawnTimer = timerLimit.RandomValue();
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = RandomVector.Range(
            cameraGameBound.WorldTopLeft, 
            cameraGameBound.WorldTopRight);
        GameObject gObject = ObjectPool.instance.Spawn("Ball", spawnPosition, Quaternion.identity);
        
        Ball ball = gObject.GetComponent<Ball>();

        float size = scaleLimit.RandomValue();
        float speed = CalculateSpeedFromSize(size);
        
        ball.SetSpriteColor(Random.ColorHSV());
        ball.SetSize(size);
        ball.SetFallSpeed(speed * fallSpeedMultiplier);

        ball.OnClick = () => AddScoreToSize(size);
    }

    private void AddScoreToSize(float size)
    {
        StatsManager.Score += Mathf.RoundToInt(scaleLimit.Max / size);
    }

    private float CalculateSpeedFromSize(float size)
    {
        return size / scaleLimit.Min - 1f;
    }
}