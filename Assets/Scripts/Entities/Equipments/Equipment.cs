using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color {
    Red,
    Blue,
    Yellow,
    White
}

public class Equipment : Entity
{
    #region States
    public EquipmentIdleState IdleState { get; protected set; }
    public EquipmentMoveState MoveState { get; protected set; }
    public EquipmentEffectState EffectState { get; protected set; }
    #endregion

    #region Inputs
    protected float xInput;
    protected float yInput;
    protected bool leftClickInput;
    protected bool rightClickInput;
    protected bool spaceClickInput;


    public float XInput
    {
        get { return xInput; }
        set { xInput = value; }
    }

    public float YInput
    {
        get { return yInput; }
        set { yInput = value; }
    }

    public bool LeftClickInput
    {
        get { return leftClickInput; }
        set { leftClickInput = value; }
    }

    public bool RightClickInput
    {
        get { return rightClickInput; }
        set { rightClickInput = value; }
    }

    public bool SpaceClickInput
    {
        get { return spaceClickInput; }
        set { spaceClickInput = value; }
    }
    #endregion

    #region Animation References
    public float LastX { get; set; }
    public float LastY { get; set; }
    public float RedLastX { get; set; }
    public float RedLastY { get; set; }
    #endregion

    #region Equipment Data
    [SerializeField] protected EquipmentData equipmentData;
    #endregion

    #region Categorize Equipment
    public Color color { get; protected set; }
    #endregion

    #region Equipment Stats 
    public bool OnCooldown { get; set; } 
    public float Cooldown { get; set; }
    protected float cooldownTimer;
    public float Range { get; set; }
    #endregion

    #region Color Droplet Upgrades 
    public int colorDropletStack { get; set; } = 0;
    #endregion

    #region Player Parent Script
    public Player player { get; set; }
    #endregion
    
    protected override void Awake()
    {
        base.Awake();
        player = transform.parent.parent.gameObject.GetComponent<Player>();
        OnCooldown = false;
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
        cooldownTimer = Cooldown;
    }

    protected override void Update()
    {
        base.Update();
        if (cooldownTimer > 0 && OnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer <= 0)
        {
            cooldownTimer = Cooldown;
            OnCooldown = false;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //For additional work needed when stats on equipment are upgraded
    public virtual void setUpgrade()
    {

    }
}
