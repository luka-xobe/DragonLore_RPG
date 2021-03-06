using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{

    

    public class Fighter : MonoBehaviour, IAction
    {
        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;
        Health health;
        Weapon weapon;

        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Weapon defaultWeapon = null;
        

        private void Start()
        {
            EquipWeapon(defaultWeapon);
            health = GetComponent<Health>();

            //Blocking();
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(rightHandTransform, leftHandTransform ,animator);
            Debug.Log("You took" + weapon);
        }

        float currentDamage = 0;
      
       
           




            private void Update()
        {

           


                timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.IsDead()) return;


            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
                
            }
            else
            {
                GetComponent<Mover>().Cancel();
                
                AttackBehaviour();
                transform.LookAt(target.transform);
            }

        }

        private void AttackBehaviour()
        {

            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // this will trigger Hit() 
                TriggerAttack();
                timeSinceLastAttack = 0;


                //Health healthComponent = target.GetComponent<Health>();
                //healthComponent.TakeDamage(weapon.weaponDamage);

            }


        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }



        //Animation Event
        void Hit()
        {
            if (target == null) { return; }
            //target.TakeDamage(currentWeapon.GetDamage());

            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(rightHandTransform, leftHandTransform, target);
            }
            else
            {
                target.TakeDamage(currentWeapon.GetDamage());
            }
        }

        void Shoot()
        {
            Hit();

        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRange();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionSchedule>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }


            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        


    }



}
