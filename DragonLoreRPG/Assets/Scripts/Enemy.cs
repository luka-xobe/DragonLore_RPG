using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Combat;


[CreateAssetMenu(fileName = "Enemy")]
public class Enemy : ScriptableObject
{
   
    
    public string name;
    public string description;
    public string race;
    public int age;
    public string gender;
    public Sprite Icon;

    //public MeshFilter meshFilter;
    //public MeshRenderer meshRenderer;
    //public Animator animator;


    public void Info()
    {
        Debug.Log(name + ": " + description);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
