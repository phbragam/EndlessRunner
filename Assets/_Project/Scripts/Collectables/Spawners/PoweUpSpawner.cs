using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpSpawner : MonoBehaviour
{
    [SerializeField] private float _powerUpChance;

    [SerializeField] private Transform _powerUpSpawnTransformLeft;
    [SerializeField] private Transform _powerUpSpawnTransformCenter;
    [SerializeField] private Transform _powerUpSpawnTransformRight;

    [SerializeField] private GameObject _slowSpeedPowerUp;
    [SerializeField] private GameObject _increaseJumpPowerUp;

    public void Initialize()
    {
        GameObject powerUp = ChoosePowerUp();
        PlacePoweUp(powerUp);
    }

    public GameObject ChoosePowerUp()
    {
        _powerUpChance = Random.Range(0f, 100f);

        if (_powerUpChance < 5f)
        {
            float random = Random.Range(0f, 1f);
            if (random < .5f)
            {
                _slowSpeedPowerUp.SetActive(false);
                _increaseJumpPowerUp.SetActive(true);

                return _increaseJumpPowerUp;
            }
            else
            {
                _slowSpeedPowerUp.SetActive(true);
                _increaseJumpPowerUp.SetActive(false);

                return _slowSpeedPowerUp;
            }
        }
        else
        {
            DeactivatePowerUps();
            return null;
        }
    }

    public void PlacePoweUp(GameObject powerUp)
    {
        int obstacleSpawnIndex = Random.Range(0, 3);
        Vector3 spawnPoint = new Vector3();

        switch (obstacleSpawnIndex)
        {
            case (0):
                spawnPoint = _powerUpSpawnTransformLeft.position;
                break;
            case (1):
                spawnPoint = _powerUpSpawnTransformCenter.position;
                break;
            case (2):
                spawnPoint = _powerUpSpawnTransformRight.position;
                break;
            default:
                spawnPoint = _powerUpSpawnTransformCenter.position;
                break;
        }

        powerUp.transform.position = spawnPoint;
    }

    public void DeactivatePowerUps()
    {
        _slowSpeedPowerUp.SetActive(false);
        _increaseJumpPowerUp.SetActive(false);
    }

    private void Awake()
    {
        Initialize();
    }
}
