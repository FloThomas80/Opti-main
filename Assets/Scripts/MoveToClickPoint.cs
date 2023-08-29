using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class MoveToClickPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navmesh;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                // si le click souris à donné une position acceptable on met à jour la destination de l'agent
                // après avoir vérifier que l'on a bien un navmeshagent sur le gameobject pour éviter une nullreferenceexeption
                // on oublie pas de prévenir 'intégrateur pour ses tests
                    _navmesh.destination = hit.point;
                    _navmesh.isStopped = false;
                   // Debug.Log("Player destination have been changed !");
            }
        }
        //on vérifie si le player est arrivé à destination
        if (Vector3.Distance(transform.position , _navmesh.destination) < 0.1f)
        {
            // toujours la vérif de la présence du component pour éviter la nullreference
                _navmesh.isStopped = true;
        }

        //on met à jour l'animation en fonction de la vitesse de l'agent
        //après avoir vérifier que le component est bien là pour éviter la nullreference
        if (_navmesh != null && _navmesh.velocity.magnitude > .1f)
        {
            GetComponentInChildren<Animator>().SetBool("running", true);
            //Debug.Log("start walking");
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("running", false);
            //Debug.Log("start running");
        }
    }
}

