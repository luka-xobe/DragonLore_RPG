using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Movement;
using RPG.Control;
using RPG.Core;

//Scripts
[RequireComponent(typeof(CombatTarget))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(AIController))]
[RequireComponent(typeof(ActionSchedule))]
[RequireComponent(typeof(Fighter))]

//Other
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]




public class Display : MonoBehaviour
{

    //public Enemy enm;
    public Enemy enemy;
    public MeshRenderer meshRender;


    // Start is called before the first frame update
    void Start()
    {
        enemy.Info();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
