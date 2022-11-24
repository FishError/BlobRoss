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
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Setting the upgrade if more work needs to be done for them. Look at RedEquipment.cs for example
    public virtual void setUpgrade()
    {

    }
}
