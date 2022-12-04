using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] private float _velocity = 0.75f;

    private Rigidbody RbEnemy;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        RbEnemy = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FocusVector = (Player.transform.position - transform.position).normalized;
        RbEnemy.AddForce(FocusVector * _velocity);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
