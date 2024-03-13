// using System.Collections;
// using System.Collections.Generic;
// using Pancake.Threading.Tasks;
// using Spine;
// using Spine.Unity;
// using UnityEngine;
// using UnityEngine.SceneManagement;

public class PopupTransition : BasePopup
{
    // [SerializeField] private SkeletonGraphic transSke;
    // [SerializeField, SpineAnimation(dataField = "ske")]
    // private string transIn;
    // [SerializeField, SpineAnimation(dataField = "ske")]
    // private string transOut;
    // protected override void ShowContent()
    // {
    //     DoTrasnsition();
    //     base.BeforeShow();
    // }
    //
    // void DoTrasnsition()
    // {
    //     transSke.AnimationState.ClearTracks();
    //     transSke.AnimationState.Complete += Complete;
    //     if (Data.IsTransforLoadingScene)
    //     {
    //         transSke.AnimationState.SetAnimation(0, transIn, false);
    //     }
    //     else
    //     {
    //         transSke.AnimationState.SetAnimation(0, transIn, false);
    //         transSke.AnimationState.AddAnimation(0, transOut, false, 0);
    //     }
    // }
    // async void Complete(TrackEntry trackEntry)
    // {
    //     if (trackEntry.Animation.Name == transOut)
    //     {
    //         Hide();
    //         transSke.AnimationState.Complete -= Complete;
    //     }
    //     if (trackEntry.Animation.Name == transIn && Data.IsTransforLoadingScene)
    //     {
    //         Data.IsTransforLoadingScene = false;
    //         Load.LoadSceneAsync(Data.SceneToLoad);
    //         await UniTask.WaitUntil((() => Load.isLoading == false));
    //         transSke.AnimationState.AddAnimation(0, transOut, false, 0);
    //         Load.isLoading = true;
    //     }
    // }
}
