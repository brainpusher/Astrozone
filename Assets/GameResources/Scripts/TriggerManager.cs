using System;
using UnityEngine;
public enum Tags
{
    Enemy = 0,
    Bullet = 1,
    Asteroid = 2
}
public class TriggerManager : MonoBehaviour
{
    public event Action OnPlayerDead = delegate { };

    [SerializeField] private bool isPlayer = false;
    [SerializeField] private Tags tagToTrigger;
    [SerializeField] private GameObject explosionPrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isPlayer)
        {
            if (other.gameObject.CompareTag(tagToTrigger.ToString()))
                ExplodeObjects(gameObject, other.gameObject);
        }
        else
        {
            ExplodeObjects(gameObject, other.gameObject);
            OnPlayerDead?.Invoke();
        }
    }

    private void ExplodeObjects(GameObject current, GameObject other)
    {
        other.SetActive(false);
        Explode();
        current.SetActive(false);
    }
    
    private void Explode () {
        GameObject explosionObject = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosionObject,1f);
    }
}

