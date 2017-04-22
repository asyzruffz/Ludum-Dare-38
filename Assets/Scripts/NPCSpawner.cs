using UnityEngine;

public class NPCSpawner : MonoBehaviour {

	public GameObject npcPrefab;
	public int population = 5;
	public float spawnHeight = 12;
	public FauxGravityAttractor planet;

	void Start () {
		for (int i = 0; i < population; i++) {
			GameObject npc = Instantiate (npcPrefab, Random.insideUnitSphere * spawnHeight, Quaternion.identity);
			npc.GetComponent<FauxGravityBody> ().attractor = planet;
		}
	}
}
