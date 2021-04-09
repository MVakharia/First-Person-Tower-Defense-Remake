using UnityEngine;
using TMPro;

public enum MachineState
{
    Off, Standby, On
}

public abstract class Machine : MonoBehaviour
{
    #region Fields
    [SerializeField]
    protected MachineState powerState;
    [SerializeField]
    protected float temperature;
    [SerializeField]
    protected CoolingSystem connectedCoolingSystem;
    [SerializeField]
    protected TMP_Text temperatureDisplay;
    [SerializeField]
    protected TMP_Text powerStateDisplay;


    public const float epoTemperature = 85;
    #endregion

    #region Properties
    protected bool MachineIsOn => powerState == MachineState.On;
    protected bool MachineIsInStandby => powerState == MachineState.Standby;
    protected bool MachineIsOff => powerState == MachineState.Off;
    protected bool MachineAboveSafeTemperature => temperature >= epoTemperature;
    protected bool GoneIntoStandby = false;
    #endregion


    protected void TurnOn() => powerState = MachineState.On;
    protected void GoIntoStandby() => powerState = MachineState.Standby;
    protected void TurnOff() => powerState = MachineState.Off;
    protected void SetTemperatureToAmbient() => temperature = WeatherController.Singleton.Temperature;
    protected void IncreaseTemperaturePerSecond(float amount) => temperature += amount * Time.deltaTime;
    protected void DecreaseTemperaturePerSecond(float amount) => temperature -= amount * Time.deltaTime;
    protected void HeatUp() => IncreaseTemperaturePerSecond(2);
    protected void CheckAsGoneIntoStandby() => GoneIntoStandby = true;
    protected void UncheckAsGoneIntoStandby() => GoneIntoStandby = false;
    protected void CoolDown() => DecreaseTemperaturePerSecond(1);
    protected void EPO ()
    {
        if(MachineAboveSafeTemperature)
        {
            TurnOff();
        }
    }

   

    protected void ThisStart ()
    {
        SetTemperatureToAmbient();

        TurnOn();
    }

    protected void ThisUpdate ()
    {
        temperatureDisplay.text = temperature.ToString("0.0") + "C";

        powerStateDisplay.text = powerState.ToString();


        if(GameManager.Singleton.IsInBuildPhase && !GoneIntoStandby)
        {
            if(MachineIsOn)
            {
                CheckAsGoneIntoStandby();

                GoIntoStandby();
            }
        }

        if(GameManager.Singleton.IsInAssaultPhase)
        {
            if(MachineIsInStandby)
            {

            }
        }

        if (MachineIsOn)
        {
            HeatUp();
        }

        if(MachineIsOff)
        {
            CoolDown();
        }

        EPO();
    }
}