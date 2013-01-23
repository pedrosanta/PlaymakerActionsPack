/ * Is Animation Playing - Playmaker Custom Action
  * https://github.com/pedrosanta/PlaymakerActions */

using UnityEngine;

namespace HutongGames.PlayMaker.Actions{
	
	[ActionCategory(ActionCategory.Animation)]
	[Tooltip("Checks if the specified animation is playing and stores the result in a variable.\nCheckout the Animation.IsPlaying on the Unity Documentation for further details.")]
	public class IsAnimationPlaying : FsmStateAction{
		
		[RequiredField]
		[CheckForComponent(typeof(Animation))]
		[Tooltip("The game object with the animation.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Animation)]
		[Tooltip("The name of the animation to check.")]
		public FsmString animName;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmBool storeValue;
		
		public bool everyFrame;		
		
		public override void Reset(){
			gameObject = null;
			animName = "";
			storeValue = null;
		}
		
		public override void OnEnter(){
			DoIsAnimationPlaying(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
			
			if (!everyFrame)
				Finish();
		}
		
		public override void OnUpdate(){
			DoIsAnimationPlaying(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
		}
		
		void DoIsAnimationPlaying(GameObject go){
			if (storeValue == null) return;
			
			if (go == null)
			{
				return;
			}

			if (go.animation == null)
			{
				LogWarning("Missing Animation component on GameObject: " + go.name);
				Finish();
				return;
			}

			var anim = go.animation[animName.Value];

			if (anim == null)
			{
				LogWarning("Missing animation: " + animName.Value);
				Finish();
				return;
			}
						
			storeValue.Value = go.animation.IsPlaying(animName.Value);
			
			Finish();		
		}
	}
}	
