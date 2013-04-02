/ * NGUI - Set Anchor Container - Playmaker Custom Action
  * https://github.com/pedrosanta/PlaymakerActionsPack * /

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	[Tooltip("Sets the widget and panel container of a UIAnchor.")]
	public class SetAnchorContainer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(UIAnchor))]
		public FsmOwnerDefault gameObject;
		
		[CheckForComponent(typeof(UIWidget))]
		public FsmGameObject widgetContainer;
		
		[CheckForComponent(typeof(UIPanel))]
		public FsmGameObject panelContainer;		
		
		public bool everyFrame;
		
		public override void Reset(){
			everyFrame = false;
			widgetContainer = null;
			panelContainer = null;
		}
		
		public override void OnEnter(){
			DoSetContainer(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
			
			if(!everyFrame){
				Finish();
			}
		}
		
		public override void OnUpdate(){
			DoSetContainer(gameObject.OwnerOption == OwnerDefaultOption.UseOwner ? Owner : gameObject.GameObject.Value);
		}
		
		void DoSetContainer(GameObject go){
			
			if (go == null) return;
			
			if (go.GetComponent<UIAnchor>() == null)
			{
				LogWarning("Missing NGUI UIAnchor component: " + go.name);
				return;
			}			
			
			UIAnchor anchor = go.GetComponent<UIAnchor>();
			
			// If a Game Object was provided
			if(widgetContainer.Value != null){
				if(widgetContainer.Value.GetComponent<UIWidget>() != null)
					anchor.widgetContainer = widgetContainer.Value.GetComponent<UIWidget>();
				else
					LogWarning("Provided Widget Container Game Object is missing NGUI UIWidget component: " + go.name+". Anchor widget container not updated.");
			}
			// If a Game Object wasn't provided set the container as null
			else
				anchor.widgetContainer = null;
			
			// If a Game Object was provided
			if(panelContainer.Value != null){
				if(panelContainer.Value.GetComponent<UIPanel>() != null)
					anchor.panelContainer = panelContainer.Value.GetComponent<UIPanel>();
				else
					LogWarning("Provided Panel Container Game Object is missing NGUI UIPanel component: " + go.name+". Anchor panel container not updated.");
			}
			// If a Game Object wasn't provided set the container as null
			else
				anchor.panelContainer = null;
		}
	}
}