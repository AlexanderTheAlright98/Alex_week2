using UnityEngine;

public class Contraband : MonoBehaviour
{
    public GameObject contrabandPrefab;

    // For the randomly spawning crates, I followed along to parts of a YouTube video, repurposing it for what I need. Link: https://www.youtube.com/watch?v=IbiwNnOv5So
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerCar")
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-102.3f, 113.4f), 0.33f, Random.Range(-22.5f, 38.3f));
            Instantiate(contrabandPrefab, randomSpawnPosition, Quaternion.identity);
            Vector3 randomSpawnPosition2 = new Vector3(Random.Range(-25.2f, 53.63f), 0.33f, Random.Range(79.6f, 235.9f));
            Instantiate(contrabandPrefab, randomSpawnPosition2, Quaternion.identity);
            Vector3 randomSpawnPosition3 = new Vector3(Random.Range(-184.8f, -88.1f), 0.33f, Random.Range(80.5f, 277.3f));
            Instantiate(contrabandPrefab, randomSpawnPosition3, Quaternion.identity);
            Destroy(gameObject);
            // Putting Destroy at the beginning of this block of code results in the cloned crates not reading the Update code (i.e. they don't spin)
            // Crates can spawn inside buildings and mountains, but I currently don't know the way to exclude certain areas from the "list" of where things can spawn
        }
    }
}
