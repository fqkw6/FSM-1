using UnityEngine;
using System.Collections;
using FSM;

public class test : MonoBehaviour
{
    public float speed;

    private LOStateMeachine _fsm;

    private LOState _idle;
    private LOState _move;

    private LOTransition _idleMove;
    private LOTransition _moveIdle;


    private bool _isMove = false;

    void Start()
    {
        _idle = new LOState("Idle");
        _idle.OnEnter += _idle_OnEnter;
        _idle.OnExit += _idle_OnExit;

        _move = new LOState("Move");
        _move.OnUpdate += _move_OnUpdate;

        _idleMove = new LOTransition("IdleMove", _idle, _move);
        _idleMove.OnCheck += _idleMove_OnCheck;
        _idle.AddTranstion(_idleMove);

        _moveIdle = new LOTransition("MoveIdle", _move, _idle);
        _moveIdle.OnCheck += _moveIdle_OnCheck;
        _move.AddTranstion(_moveIdle);

        _fsm = new LOStateMeachine("Root", _idle);
        _fsm.AddState(_move);
    }

    void _idle_OnExit(IState state)
    {
        Debug.LogError("sssssssssssssssss");
    }

    bool _moveIdle_OnCheck()
    {
        return !_isMove;
    }

    bool _idleMove_OnCheck()
    {
        return _isMove;
    }

    void _move_OnUpdate(float f)
    {
        transform.position += transform.forward * f * speed;
    }

    void _idle_OnEnter(IState state)
    {
        Debug.LogError("uxjjx");
    }

    void Update()
    {
        _fsm.UpdateCallback(Time.deltaTime);
    }


    void OnGUI()
    {
        if (GUILayout.Button("Move"))
        {
            _isMove = true;
        }
        if (GUILayout.Button("Idle"))
        {
            _isMove = false;
        }
    }
}
