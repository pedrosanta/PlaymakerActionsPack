using UnityEngine;

namespace HutongGames.PlayMaker.Actions {
		
	[ActionCategory("NGUI")]
	[Tooltip("Sets the relative offset of a UIAnchor. The axis values if different than 0/None will override the Vector ones.")]
	public class SetAnchorRelativeOffset : FsmStateAction {

		[RequiredField]
		[CheckForComponent(typeof(UIAnchor))]
		public FsmOwnerDefault gameObject;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Use a stored Vector2 offset, and/or set individual axis below.")]
		public FsmVector2 vector;
		
		public FsmFloat x;
		public FsmFloat y;
		
		public bool everyFrame;
		
		public override void Reset(){
			gameObject = null;
			vector = null;
			x = new FsmFloat { UseVariable = true };
			y = new FsmFloat { UseVariable = true };
			everyFrame = false;
		}
		
		public override void OnUpdate(){
			DoSetRelativeOffset(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
		}		
		
		public override void OnEnter(){
			DoSetRelativeOffset(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
			
			if(!everyFrame){
				Finish();
			}
		}		
		
		void DoSetRelativeOffset(GameObject go){
			if (go == null) return;
			
			if (go.GetComponent<UIAnchor>() == null)
			{
				LogWarning("Missing NGUI UIAnchor component: " + go.name);
				return;
			}
			
			UIAnchor anchor = go.GetComponent<UIAnchor>();
			
			// Init offset
			Vector2 offset = Vector2.zero;
			
			// If there's a vector update offset
			if (!vector.IsNone)
				offset = vector.Value;
			
			// If there are axis values, override vector values
			if (!x.IsNone)
				offset.x = x.Value;
			if (!y.IsNone)
				offset.y = y.Value;
			
			// Set the offset
			anchor.relativeOffset = offset;
		}
	}
}

