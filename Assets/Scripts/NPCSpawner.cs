using UnityEngine;

public class NPCSpawner : MonoBehaviour {

	public GameObject npcPrefab;
	public int population = 5;
	public FauxGravityAttractor planet;

	void Start () {
		for (int i = 0; i < population; i++) {
			GameObject npc = Instantiate (npcPrefab, Random.insideUnitSphere * planet.transform.lossyScale.x / 2f, Quaternion.identity, transform);
			npc.GetComponent<FauxGravityBody> ().attractor = planet;
		}
	}
}
