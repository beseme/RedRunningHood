using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "new Actor", menuName = "InputMethod")]
public class Actor : ScriptableObject
{
    //Objects and Physics
    public GameObject ice;
    public GameObject Fire;
    public GameObject Bolt;
    
    //floating values
    [SerializeField] private float _fallMultiplier = 3f;
    public float FallMultiplier => _fallMultiplier;
    private float _jumpMultiplier = 4;
    public float JumpMultiplier => _jumpMultiplier;
    [SerializeField] private float _jumpHeight = 0;
    public float JumpHeight => _jumpHeight;
    [SerializeField] private float _speed = 0;
    public float Speed => _speed;
    [SerializeField] private float _coyoteTime = 0;
    public float CoyoteTime => _coyoteTime;

    [SerializeField] private float _cooldown = 0;

    public float Cooldown => _cooldown;

    //boolean
    public bool Rolling;
    public bool Jumping;
    public bool JumpInitiated;
    public bool Lightweight;
    

    public IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(.1f);
        JumpInitiated = false;
    }
}
