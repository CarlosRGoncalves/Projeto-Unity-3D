using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class monstro : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if(target == null)
           target = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = target.transform.position;

    }
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
             SceneManager.LoadScene(0);
             Destroy(gameObject);
        }
       
        }
}
