using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Combat;
public class Projectile : MonoBehaviour
{
    
    [SerializeField] float speed = 1;
    [SerializeField] bool isHoming = true;

    Health target = null;
    float damage = 0;

    private void Start()
    {
        transform.LookAt(GetAimLocation());
    }


    void Update()
    {
        if (target == null) return;


        if (isHoming)
        {
            if (!target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetTarget(Health target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Worked");
        if (other.GetComponent<Health>() != target) return;
        if (target.IsDead()) return;
        target.TakeDamage(damage);
        Destroy(gameObject);
        

        //Weapon weapon;
        //weapon = GetComponent<Weapon>();

        //Health healthComponent = target.GetComponent<Health>();
        //healthComponent.TakeDamage(weapon.weaponDamage);
    }


    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
           
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }

}