using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPowers", menuName = "ScriptableObjects/PlayerPower", order = 1)]
public class PowerState : ScriptableObject
{
    public PowerTypes type;
    public GameObject bullet;
    public AudioClip bulletSound;
    public float duration;
    public float speedMultiplier;

    public Material skin;
    public GameObject particles;
    public GameObject onPowerupParticles;

}
