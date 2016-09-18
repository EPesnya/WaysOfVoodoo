using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InputController : MonoBehaviour {

    public delegate void Code();
    public delegate bool Condition();

    public class Action
    {
        Code code;
        Condition condition;
        Condition AlwaysCondition = () => { return true; };
        public Action(Code Code, Condition Condition = null)
        {
            code = Code;
            condition = Condition;
        }
        public void Run()
        {
            if (condition == null || condition())
                code();
        }
    }
    Dictionary<string, Action> KeyBinds;
	void Start () {
        KeyBinds = new Dictionary<string, Action>();
	}
	public InputController Bind(string KeyCode, Action Action)
    {
        KeyBinds.Add(KeyCode, Action);
        return this;
    }
	void FixedUpdate () {
        foreach (KeyValuePair<string, Action> kvp in KeyBinds)
        {
            bool allKeysPressed = true, allKeysUnpressed = true;
            string[] keys = kvp.Key.Split('|');
            bool KeyDownFlag = false, NotFlag = false, skipFlags = false;
            for(int i = 0; i < keys[0].Length; i++)
            {
                if (keys[0][i] == '!')
                    NotFlag = true;
                if (keys[0][i] == '*')
                    KeyDownFlag = true;
            }
            skipFlags = NotFlag || KeyDownFlag;
            for (int i = skipFlags ? 1 : 0; i < keys.GetLength(0); i++)
            {
                if(KeyDownFlag == false)
                    if (Input.GetKey(keys[i]))
                        allKeysUnpressed = false;
                    else
                        allKeysPressed = false;
                else
                    if (Input.GetKeyDown(keys[i]))
                        allKeysUnpressed = false;
                    else
                        allKeysPressed = false;
            }
            //Debug.Log(allKeysPressed.ToString() + " " + allKeysUnpressed.ToString() + " " + kvp.Key);
            if (allKeysPressed && keys[0][0] != '!')
            {
                kvp.Value.Run();
            }
            if(allKeysUnpressed && keys[0][0] == '!')
                kvp.Value.Run();
        }
    }
}
