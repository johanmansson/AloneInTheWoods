using UnityEngine;

public class FireLightScript : MonoBehaviour
{
	public float minIntensity = 0.5f;
	public float maxIntensity = 0.8f;



	public Light fireLight;


	float random;

	void Start(){
		InvokeRepeating("ChangeLightIntensity", 2.0f, 2.0f);
	}

	void ChangeLightIntensity()
	{

		minIntensity -= 0.14f;
		maxIntensity -= 0.14f;

	}

	void Update()
	{
		random = Random.Range(0.0f, 150.0f);
		float noise = Mathf.PerlinNoise(random, Time.time);
		fireLight.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

	}
}