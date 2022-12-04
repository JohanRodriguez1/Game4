using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity = 4.0f;

    [SerializeField] private float _forcePowerUp = 10.0f;
    [SerializeField] private float _timePowerUp = 10.0f;
    
    [SerializeField] private GameObject PowerUpIndicator;
    
    private bool _powerUp = false;
    private Rigidbody _rbPlayer;
    private GameObject _focusPoint;

    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _focusPoint = GameObject.Find("AnchorCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float MoveInput = Input.GetAxis("Vertical");
        _rbPlayer.AddForce(_focusPoint.transform.forward * MoveInput * _velocity);

        PowerUpIndicator.transform.position = transform.position + new Vector3 (0, 0.115f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _powerUp = true;
            PowerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(TimePowerUp(_timePowerUp));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _powerUp)
        {
            Rigidbody RbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 ThrowEnemy = (collision.gameObject.transform.position - transform.position);
            RbEnemy.AddForce(ThrowEnemy * _forcePowerUp, ForceMode.Impulse);
        }
    }

    IEnumerator TimePowerUp(float TimePowerUp)
    {
        yield return new WaitForSeconds(TimePowerUp);
        _powerUp = false;
        PowerUpIndicator.gameObject.SetActive(false);
    }
}
