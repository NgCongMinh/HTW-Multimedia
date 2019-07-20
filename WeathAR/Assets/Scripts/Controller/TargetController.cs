using DefaultNamespace;
using Model;
using Network;
using TMPro;
using UnityEngine;
using Util;

namespace Controller
{
    public class TargetController : MonoBehaviour
    {
        private WeatherApiClient weatherClient;

        private GameObject currentWeatherContainer;

        private GameObject backwardButton;

        private GameObject forwardButton;

        private Identifier currentIdentifier;

        private DayType currentDayType;

        public void Start()
        {
            weatherClient = GameObject.Find("WeatherApiClient").GetComponent<WeatherApiClient>();
        }

        public void Register(GameObject target)
        {
            UnregisterPreviousListener();

            currentWeatherContainer = target.transform.Find("WeatherDataContainer").gameObject;
            currentWeatherContainer.SetActive(true);

            // do not activate
            backwardButton = target.transform.Find("BackwardButton").gameObject;

            // activate button to enable behaviour
            forwardButton = target.transform.Find("ForwardButton").gameObject;
            forwardButton.SetActive(true);

            currentIdentifier = currentWeatherContainer.GetComponent<Identifier>();

            WeatherContainerButtonController buttonController = target.GetComponent<WeatherContainerButtonController>();
            buttonController.Bind(UpdateView);
        }

        private void UnregisterPreviousListener()
        {
            if (currentWeatherContainer == null) return;

            currentWeatherContainer.SetActive(false);
            backwardButton.SetActive(false);
            forwardButton.SetActive(false);

            currentWeatherContainer = null;
            backwardButton = null;
            forwardButton = null;
            currentIdentifier = null;
        }

        private void UpdateView(DayType dt)
        {
            currentDayType = dt;
            weatherClient.GetWeather(currentIdentifier.city.ToLower(), HandleResponse);
        }

        private void HandleResponse(WeatherForecast weatherForecast)
        {
            WeatherReport weatherReport;
            switch (currentDayType)
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
            
            // location
            SetLocation(weatherReport.location);
                
            // day type
            SetDayTypeLabel(currentDayType);

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

                Transform phenomenaComponent = currentWeatherContainer.transform.Find(phenomenaComponentName);
                phenomenaComponent.GetComponent<MeshRenderer>().material = material;
            }
        }

        private void SetTemperature(double temperature, string componentName)
        {
            if (Settings.temperatureUnit == TemperatureUnit.Fahrenheit)
            {
                double temp = TemperatureConverter.ToFahrenheit(temperature);
                SetText(string.Format("{0:0.00}", temp) + "°F", componentName);
            }
            else
            {
                SetText(string.Format("{0:0.00}", temperature) + "°C", componentName);
            }
        }

        private void SetLocation(string location)
        {
            SetText(location, "Location");
        }

        private void SetDayTypeLabel(DayType dayType)
        {
            SetText(DayTypeConverter.getLabel(dayType), "Day");
        }

        private void SetText(object text, string componentName)
        {
            Transform textComponent = currentWeatherContainer.transform.Find(componentName);
            TextMeshPro txt = textComponent.GetComponent<TextMeshPro>();
            txt.text = text.ToString();
        }
    }
}