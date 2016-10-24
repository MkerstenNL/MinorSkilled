using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BehaviourManager : MonoBehaviour {

    CustomBehaviour[] _behaviourList;
    Dictionary<string, LuaBehaviour> _luaBehaviours = new Dictionary<string, LuaBehaviour>();
    GameObject CurrentObject;
    [SerializeField]GameObject empty;
    [SerializeField]GameObject _variableCanvas;
    [SerializeField]GameObject _luaCanvas;
    [SerializeField]LuaCanvasManager _luaManager;

    [SerializeField]Dropdown _dropDown;
    [SerializeField]Dropdown _luaDropdown;
    public static bool UsingHud = false;
    CustomBehaviour behaviour;
    [SerializeField]GameObject _variableHolder;
    [SerializeField]GameObject inputFieldPrefab;
    List<GameObject> _inputFields = new List<GameObject>();

    void Start() {
        _behaviourList = gameObject.GetComponentsInChildren<CustomBehaviour>();
        _dropDown.onValueChanged.AddListener(OnClickBehaviourButton);
    }
   
    public void AddBehaviour(GameObject g) {
        UsingHud = true;
        CurrentObject = g;

        //CurrentObject.AddComponent(_behaviourList[0].GetType());
        //MovementBehaviour m = (MovementBehaviour)CurrentObject.GetComponent(_behaviourList[0].GetType());
        //return;
        List<string> options = new List<string>();
        _dropDown.options.Clear();
        _dropDown.options.Add(new Dropdown.OptionData("No Behaviour selected"));
        _dropDown.options.Add(new Dropdown.OptionData("new Lua Behaviour"));
        _dropDown.options.Add(new Dropdown.OptionData("Existing Lua Behaviour"));
        for ( int i = 0; i < _behaviourList.Length; i++ ) {
            //_behaviourList[i].GetName();
            _dropDown.options.Add(new Dropdown.OptionData(_behaviourList[i].GetName()));
        }
        
        
        
        _dropDown.value = 0;
        _dropDown.RefreshShownValue();
       // Debug.Log(_behaviourList.Length);
        //
        //_dropDown.AddOptions(options);
        _dropDown.gameObject.transform.parent.gameObject.SetActive(true);
        _dropDown.value = 0;
        
        //_dropDown.onValueChanged

    }

    public void AddLuaBehaviour(LuaBehaviour pLuaBheaviour) {

    }

    public void OnClickBehaviourButton(int index) {
        if(UsingHud==false)return;
        
        _dropDown.value = index;
        _dropDown.RefreshShownValue();
        switch ( index ) {
            case 0:
                return;
                

            case 1:
                CreateNewLuaBehaviour();
                return;

            case 2:
                createNewExistingLuaBehaviour();
                
                return;

            default:
                CreateBehaviour(index - 3);
                return;


        }

    }

    private void createNewExistingLuaBehaviour() {
        _luaDropdown.gameObject.SetActive(true);
        foreach ( KeyValuePair<string,LuaBehaviour> key in _luaBehaviours ) {
            _luaDropdown.options.Add(new Dropdown.OptionData(key.Key));
        }
        Debug.Log(_luaBehaviours.Count);
    }

    private void CreateNewLuaBehaviour() {
        _luaManager.Enable("",CurrentObject);
       // GameObject gameObject = Instantiate<GameObject>(empty);
       // LuaBehaviour lua = gameObject.AddComponent<LuaBehaviour>();
        //behaviour = lua;
        //_luaCanvas.SetActive(true);


    }
    //Should show AddVariableMenu
    public void AddLuaVariableButton() {
        _variableCanvas.SetActive(true);

    }
    /// <summary>
    /// ToDO
    /// </summary>
    public void CreateLuaFile() {
       /* _luaCanvas.SetActive(false);
        InputField[] inputfields = _luaCanvas.GetComponentsInChildren<InputField>();
        string luaCode = _luaCanvas.GetComponentInChildren<InputField>().text;
        Debug.Log(luaCode);
        LuaBehaviour lua = CurrentObject.AddComponent<LuaBehaviour>();
        LuaCSharpFunctions csharp = CurrentObject.AddComponent<LuaCSharpFunctions>();
        _luaBehaviours.Add(lua);
        //LuaBehaviour.CreateLuaScriptForObject(CurrentObject, lua);
        lua.SaveLua(luaCode, "test");
        lua.Init();*/
        Cancel();
        //write to lua shizzle
    }

    public void AddLuaVariable() {
        InputField[] objects = _variableCanvas.gameObject.GetComponentsInChildren<InputField>();
        int nameID = -1 ;
        int valueID = -1;
        for ( int i = 0; i < objects.Length; i++ ) {
            if(objects[i].name == "Name")nameID=i;
            if(objects[i].name == "Value")valueID=i;
        }
        behaviour.VariableList.Add(objects[nameID].text, objects[valueID].text);
        _variableCanvas.SetActive(false);
    }

    private void CreateBehaviour(int index) {
        //if (index <= 1)return;
        System.Type T = _behaviourList[index].GetType();
        behaviour = (CustomBehaviour)CurrentObject.AddComponent(T);
        int i = 0;
        foreach ( KeyValuePair<string, object> key in behaviour.VariableList ) {
            GameObject obj = Instantiate(inputFieldPrefab);
            obj.name = key.Key;
            obj.GetComponent<InputField>().text = key.Key;
            obj.transform.SetParent(_variableHolder.transform);
            //obj.transform.position = new Vector3(0, 0 - i * 30, 0);
            _inputFields.Add(obj);
            i++;

        }
        //behaviour.Init();
        
    }

    public void ValueInserted() {

    }

    public void Create() {
       // if ( _dropDown.value > 3 ) {
       for ( int i = 0; i < _inputFields.Count; i++ ) {
            InputField field = _inputFields[i].GetComponent<InputField>();
            behaviour.VariableList[_inputFields[i].name] = ConvertToType(field);
       }
            behaviour.Init();
       // } else if ( _dropDown.value == 1 ) {

       // } else if(_dropDown.value == 2){
       //
       // }
        Cancel();
    }

    private object ConvertToType(InputField field) {
        Type t = behaviour.VariableList[field.name].GetType();
        Debug.Log(t.ToString());
        if ( t == typeof(float) ) {
            return float.Parse(field.text);
        } else if(t == typeof(MovementBehaviour.Direction)){

            return Enum.Parse(typeof(MovementBehaviour.Direction), field.text);
            
        }
        return null;
    }

    public void Cancel() {
        UsingHud = false;
        for(int i =0;i<_inputFields.Count;i++ )GameObject.Destroy(_inputFields[i].gameObject);
        _inputFields.Clear();
        CurrentObject = null;
        behaviour = null;
        _dropDown.gameObject.transform.parent.gameObject.SetActive(false);
        UsingHud = false;
        _luaDropdown.gameObject.SetActive(false);
    }


  
}

