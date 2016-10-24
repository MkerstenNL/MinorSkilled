using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LuaCanvasManager : MonoBehaviour {

    [SerializeField] InputField _luaSource;
    [SerializeField] InputField _fileName;
    [SerializeField] BehaviourManager _behaviourManager;
    string filename = "";
    string source = "";

    GameObject currentObject;

    public void Enable(string pFileName=null, GameObject pCurrentObject=null) {
        if (pCurrentObject==null)return;
        this.gameObject.SetActive(true);
        currentObject = pCurrentObject;
        if ( pFileName == "" || pFileName == null )return;
        loadLuaFile(pFileName);
    }

    public void Disable() {
        _luaSource.text = "";
        _fileName.text = "";
        this.gameObject.SetActive(false);

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FileNameEntered(string pFilename) {
        Debug.Log(pFilename);
        filename = pFilename;
    }

    public void SourceCodeEntered(string pSource) {
        source = pSource;

    }

    public void CreateFile() {
        LuaBehaviour lua = currentObject.AddComponent<LuaBehaviour>();
        LuaCSharpFunctions csharp = currentObject.AddComponent<LuaCSharpFunctions>();
        _behaviourManager.AddLuaBehaviour(lua);
        LuaBehaviour.CreateLuaScriptForObject(currentObject, lua, filename);
        lua.SaveLua(source, filename);
        lua.Init();
        Disable();

    }

    private void loadLuaFile(string pFileName) {

    }
}
