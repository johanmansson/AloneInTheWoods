using UnityEngine;

public class FireLightScript : MonoBehaviour
{
    public float startMinIntensity = -2f;
    public float startMaxIntensity = 0f;
    public float minIntensity = -2f;
	public float maxIntensity = 0f;

    int lifeTime = 60;
    float decreaseIntensity = (float)(5.0f/60.0)*0.7f;


	public Light fireLight;


	float random;

	void Start(){
        random = Random.Range(0.0f, 150.0f);
        float noise = Mathf.PerlinNoise(random, Time.time);

       


        fireLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 2, noise);

        //decreaseIntensity = (startMaxIntensity / lifeTime)*0.7f;

        
	}

    public void startLight()
    {
        InvokeRepeating("GrowLight", 0f, 1);
        


    }

    void GrowLight()
    {
        minIntensity += (float)5 / 12;
        maxIntensity += (float)5 / 12;
        if (maxIntensity >= 5)
        {
            
            InvokeRepeating("ChangeLightIntensity", 0.0f, 1.0f);
            CancelInvoke("GrowLight");
           
        }
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