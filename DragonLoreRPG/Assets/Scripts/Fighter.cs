using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{

    

    public class Fighter : MonoBehaviour, IAction
    {
        Transform target;
        float timeSinceLastAttack = 0;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;

        private void Update()
        {

            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;


            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                
                AttackBehaviour();

            }

        }

        private void AttackBehaviour()
        {

            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
                Health healthComponent = target.GetComponent<Health>();
            }
                
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionSchedule>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        //Animation Event
        void Hit()
        {

        }


    }



}
