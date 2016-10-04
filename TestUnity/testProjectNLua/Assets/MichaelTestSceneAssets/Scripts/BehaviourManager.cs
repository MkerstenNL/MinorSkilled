using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BehaviourManager : MonoBehaviour {

    CustomBehaviour[] _behaviourList;
    GameObject CurrentObject;


    [SerializeField]Dropdown _dropDown;
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
        for (int i = 0; i<_behaviourList.Length; i++ ) {
            //_behaviourList[i].GetName();
            _dropDown.options.Add(new Dropdown.OptionData(_behaviourList[i].GetName()));
        }
        _dropDown.value = 0;
        _dropDown.RefreshShownValue();
       // Debug.Log(_behaviourList.Length);
        //
        //_dropDown.AddOptions(options);
        _dropDown.gameObject.SetActive(true);
        _dropDown.value = 0;
        
        //_dropDown.onValueChanged

    }

    public void OnClickBehaviourButton(int index) {
        if(UsingHud==false)return;
        _dropDown.value = index;
        _dropDown.RefreshShownValue();
        CreateBehaviour( index);

    }

    private void CreateBehaviour(int index) {
        if (index == 0)return;
        System.Type T = _behaviourList[index-1].GetType();
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
        for ( int i = 0; i < _inputFields.Count; i++ ) {
            InputField field = _inputFields[i].GetComponent<InputField>();
            behaviour.VariableList[_inputFields[i].name] = ConvertToType(field);
        }
        behaviour.Init();
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
        _dropDown.gameObject.SetActive(false);
        UsingHud = false;
    }


  
}

