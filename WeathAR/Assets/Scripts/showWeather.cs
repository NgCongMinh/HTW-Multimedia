using DefaultNamespace;
using Model;
using Network;
using TMPro;
using UnityEngine;

public class ShowWeather : MonoBehaviour
{
    private WeatherApiClient weatherClient;

    private GameObject collided;

    // Prefab
    private GameObject weatherDataContainer;

    private Identifier identifier;

    private GameObject b1;

    private SwitchDay skript;

    private DayType dayType;

    public void Start()
    {
        weatherClient = GameObject.Find("WeatherApiClient").GetComponent<WeatherApiClient>();

        collided = null;
        weatherDataContainer = null;
        b1 = null;
        skript = null;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Marker"))
        {
            if (weatherDataContainer != null)
            {
                skript = (SwitchDay) collided.GetComponent(typeof(SwitchDay));
                skript.Reset();
                weatherDataContainer.SetActive(false);
            }

            collided = col.transform.gameObject;
            weatherDataContainer = col.transform.Find("Wetterdaten").gameObject;
            identifier = weatherDataContainer.GetComponent<Identifier>();
            b1 = col.transform.Find("switch_button_forward").gameObject;

            weatherDataContainer.SetActive(true);
            b1.SetActive(true);
        }
    }

    public void UpdateView(DayType dt)
    {
        this.dayType = dt;
        InsertWeatherData();
    }

    private void InsertWeatherData()
    {
        weatherClient.GetWeather(identifier.city.ToLower(), HandleResponse);
    }

    private void HandleResponse(WeatherForecast weatherForecast)
    {
        WeatherReport weatherReport;
        switch (dayType)
        {
            case DayType.Today:
                weatherReport = weatherForecast.today;
                break;
            case DayType.Tomorrow:
                weatherReport = weatherForecast.tomorrow;
                break;
            case DayType.DayAfterTomorrow:
                weatherReport = weatherForecast.dayAfterTomorrow;
                break;
            default:
                weatherReport = null;
                break;
        }

        foreach (DayTime dayTime in weatherReport.data.Keys)
        {
            WeatherData weatherData = weatherReport.data[dayTime];

            string temperatureComponentName = null;
            string phenomenaComponentName = null;
            switch (dayTime)
            {
                case DayTime.MORNING:
                    temperatureComponentName = "MorningTemperature";
                    phenomenaComponentName = "MorningPhenomena";
                    break;
                case DayTime.NOON:
                    temperatureComponentName = "NoonTemperature";
                    phenomenaComponentName = "NoonPhenomena";
                    break;
                case DayTime.EVENING:
                    temperatureComponentName = "EveningTemperature";
                    phenomenaComponentName = "EveningPhenomena";
                    break;
                case DayTime.NIGHT:
                    temperatureComponentName = "NightTemperature";
                    phenomenaComponentName = "NightPhenomena";
                    break;
            }

            // temperature
            SetTemperature(weatherData.temperature, temperatureComponentName);

            // weather phenomena
            Material material = WeatherPhenomenaMapper.GetWeatherMaterial(weatherData.phenomena);

            Transform phenomenaComponent = weatherDataContainer.transform.Find(phenomenaComponentName);
            phenomenaComponent.GetComponent<MeshRenderer>().material = material;
        }
    }

    private void SetTemperature(double temperature, string componentName)
    {
        SetText(string.Format("{0:0.00}", temperature) + "°C", componentName);
    }

    private void SetText(object text, string componentName)
    {
        Transform textComponent = weatherDataContainer.transform.Find(componentName);
        TextMeshPro txt = textComponent.GetComponent<TextMeshPro>();
        txt.text = text.ToString();
    }
}