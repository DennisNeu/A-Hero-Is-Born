using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] private Transform patrolRoute;

    [SerializeField] private List<Transform> locations;

    private Transform player;
    private int lives = 3;
    public int EnemyLives {
        get {
            return lives;
        }
        private set {
            lives = value;

            if (lives <= 0) {
                Destroy(gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }


    private int locationIndex = 0;
    private NavMeshAgent agent;

    private void Start() {
        InitializePatrolRoute();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        MoveToNextPatrolLocation();
    }

    private void Update() {
        if (agent.remainingDistance < 0.2f && !agent.pathPending) {
            MoveToNextPatrolLocation();
        }
    }

    private void MoveToNextPatrolLocation() {
        if (locations.Count == 0) {
            return;
        }

        agent.destination = locations[locationIndex].position;
        //Debug.Log((locationIndex + 1) % locations.Count);
        //Debug.Log("location.count: " + locations.Count);
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    private void InitializePatrolRoute() {
        foreach (Transform child in patrolRoute) {
            locations.Add(child);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            agent.destination = player.position;
            Debug.Log("Player detected!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Player lost!");
        }
    }

    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name == "Bullet(Clone)") {
            EnemyLives -= 1;
            Debug.Log("Enemy hit!");
        }
    }
}
