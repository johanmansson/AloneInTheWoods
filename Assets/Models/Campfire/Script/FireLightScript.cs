using UnityEngine;

public class FireLightScript : MonoBehaviour
{
    public float startMinIntensity = 3f;
    public float startMaxIntensity = 5f;
    public float minIntensity = 0f;
	public float maxIntensity = 0f;

    int lifeTime = 60;
    float decreaseIntensity = 0f;


	public Light fireLight;


	float random;

	void Start(){
        random = Random.Range(0.0f, 150.0f);
        float noise = Mathf.PerlinNoise(random, Time.time);
        fireLight.GetComponent<Light>().intensity = Mathf.Lerp(startMinIntensity, startMaxIntensity, noise);

        decreaseIntensity = (startMaxIntensity / lifeTime)*0.7f;

        InvokeRepeating("ChangeLightIntensity", 0f, 1);
	}

	void ChangeLightIntensity()
	{

        minIntensity -= decreaseIntensity;
        maxIntensity -= decreaseIntensity;

	}

    public void Explode()
    {
        minIntensity += decreaseIntensity * 20;
        maxIntensity += decreaseIntensity * 20;
    }

	void Update()
	{
		random = Random.Range(0.0f, 150.0f);
		float noise = Mathf.PerlinNoise(random, Time.time);
		fireLight.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

	}
}