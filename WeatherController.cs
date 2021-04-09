using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public const float minimumBuildingTemperature = 17;

    [SerializeField]
    private float temperature;
    public float Temperature => temperature;

    private void SetTemperature(float temp) => temperature = temp;


    private static WeatherController singleton;

    public static WeatherController Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Weather Controller").GetComponent<WeatherController>();
            }
            return singleton;
        }
    }

    private void Start()
    {
        SetTemperature(minimumBuildingTemperature);
    }
}