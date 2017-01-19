using UnityEngine;
using System.Collections;

public class SapphiArtChan_AnimManager : MonoBehaviour
{

    private Animator _SapphiArtChanAnimator;                //Character Animation
    internal string _SapphiArtChanAnimation = null;         //Character Animation Name
    private string _SapphiArtChanLastAnimation = null;      //Character Last Animation
    
    void Start()
    {
        _SapphiArtChanAnimator = this.gameObject.GetComponent<Animator>();
        //_AnimationManagerUI = GameObject.Find("AnimationManagerUI").GetComponent<AnimationManagerUI>();

        Transform[] SapphiArtchanChildren = GetComponentsInChildren<Transform>();

    }


    void GetAnimation()
    {
        //Record Last Animation
        _SapphiArtChanLastAnimation = _SapphiArtChanAnimation;

        if (_SapphiArtChanAnimation == null)
            _SapphiArtChanAnimation = "idle";

        else
        {
            //Set Animation Parameter
            //_SapphiArtChanAnimation = "walk";// _AnimationManagerUI._Animation;
            //_SapphiArtChanAnimation = "hit01";
        }
    }

    void SetAllAnimationFlagsToFalse()
    {
        _SapphiArtChanAnimator.SetBool("param_idletowalk", false);
        _SapphiArtChanAnimator.SetBool("param_idletorunning", false);
        _SapphiArtChanAnimator.SetBool("param_idletojump", false);
    }


    void SetAnimation()
    {
        SetAllAnimationFlagsToFalse();
        //IDLE
        //if (_SapphiArtChanAnimation == "idle")
        //{
        //    _SapphiArtChanAnimator.SetBool("param_toidle", true);
        //}

        ////WALK
        //else 
        if (Input.GetKey(KeyCode.S))
        {
            _SapphiArtChanAnimation = "walk";
            _SapphiArtChanAnimator.SetBool("param_idletowalk", true);
        }

        //RUN
        else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Duurt het zo lang?");
            _SapphiArtChanAnimation = "running";
            _SapphiArtChanAnimator.SetBool("param_idletorunning", true);
        }

        //JUMP
        else if (Input.GetKey(KeyCode.Space))
        {
            _SapphiArtChanAnimation = "jump";
            _SapphiArtChanAnimator.SetBool("param_idletojump", true);
        }
        else
        {
            _SapphiArtChanAnimation = "idle";
            _SapphiArtChanAnimator.SetBool("param_toidle", true);
        }
    }

    void ReturnToIdle()
    {
        if (_SapphiArtChanAnimator.GetCurrentAnimatorStateInfo(0).IsName(_SapphiArtChanAnimation))
        {
            if (
                _SapphiArtChanAnimation != "walk" &&
                _SapphiArtChanAnimation != "running" &&
                _SapphiArtChanAnimation != "ko_big" &&
                _SapphiArtChanAnimation != "winpose"
                )
            {
                SetAllAnimationFlagsToFalse();
                _SapphiArtChanAnimator.SetBool("param_toidle", true);
            }
        }
    }




    void Update()
    {
        //Get Animation from UI
        GetAnimation();

        //Set New Animation
        //if (_SapphiArtChanLastAnimation != _SapphiArtChanAnimation)
        SetAnimation();
        //else
        //{
        ReturnToIdle();
        //}

    }
}
