using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float restTimeMin = 2f;
    public float restTimeMax = 5f;

    private NavMeshAgent agent;
    private bool isMoving = true;
    private bool isResting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(MoveCoroutine());
    }

    void Update()
    {
        if (!isResting && isMoving && agent.isActiveAndEnabled && agent.isOnNavMesh) // Verifique se o agente está ativo e na navegação
        {
            // Verifique se o agente chegou ao seu destino
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                StartCoroutine(RestCoroutine());
            }
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (isMoving && !isResting && agent.isActiveAndEnabled && agent.isOnNavMesh) // Verifique se o agente está ativo e na navegação
            {
                Vector3 targetPosition = GetRandomPosition();
                agent.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1f)); // Atualize o destino periodicamente
        }
    }

    IEnumerator RestCoroutine()
    {
        isMoving = false;
        isResting = true;

        float restTime = Random.Range(restTimeMin, restTimeMax);
        yield return new WaitForSeconds(restTime);

        isResting = false;
        isMoving = true;
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
        return hit.position;
    }

}
