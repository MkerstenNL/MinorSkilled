using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine.SceneManagement;

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
        filename = pFileName;
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
        source = LuaBehaviour.LoadLuaFile(pFilename);
        _luaSource.text = source;
    }

    public void SourceCodeEntered(string pSource) {
        source = pSource;

    }

    public void CreateFile() {
        ScriptsCheck scriptCheck = new ScriptsCheck();
        Debug.Log(_luaSource.text);
        Debug.Log(source);
        bool? canCreate = scriptCheck.CompareFiles(_luaSource.text, EditorApplication.currentScene.Replace("Assets/Scenes", "").Replace(".unity", "") + currentObject.gameObject.name);
        if (canCreate == true || canCreate == null)
        {
            LuaBehaviour lua = null;
            bool found = false;
            lua = currentObject.GetComponent<LuaBehaviour>();
            if (lua != null)
            {
                LuaBehaviour[] luaBehaviours = currentObject.GetComponents<LuaBehaviour>();
                foreach (LuaBehaviour _lua in luaBehaviours)
                {
                    if (filename != _lua.filename) continue;
                    lua = _lua;
                    //source = lua.source;
                    found = true;
                    break;

                }
            }
            LuaCSharpFunctions csharp = currentObject.GetComponent<LuaCSharpFunctions>();
            if (csharp != null)
            {
                csharp.Invalidate();
            }
            else
            {
                csharp = currentObject.AddComponent<LuaCSharpFunctions>();
            }

            if (lua == null || !found)
            {
                lua = currentObject.AddComponent<LuaBehaviour>();
                _behaviourManager.AddLuaBehaviour(lua);
                LuaBehaviour.CreateLuaScriptForObject(currentObject, lua, filename);
            }
            lua.SaveLua(source, filename);
            Disable();
            _behaviourManager.Cancel();
            if (canCreate == null)
            {
                SceneManager.LoadScene("Level1");
            }
            scriptCheck.NextLevelCheck(source);
        }
        else
        { Debug.Log("The files are not the same"); }

    }

    private void loadLuaFile(string pFileName) {
        _fileName.text = pFileName;
        source = LuaBehaviour.LoadLuaFile(pFileName);
        _luaSource.text = source;
        
    }
}
