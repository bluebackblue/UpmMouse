

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief エンジン。
*/


/** define
*/
#if(ASMDEF_COM_UNITY_INPUTSYSTEM)
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.Mouse.UIS
*/
#if(ASMDEF_TRUE)
namespace BlueBack.Mouse.UIS
{
	/** Engine
	*/
	public sealed class Engine : Engine_Base
	{
		/** param
		*/
		public Param param;

		/** constructor
		*/
		public Engine(in InitParam a_initparam)
		{
			this.param.device = a_initparam.device;
			this.param.enable = false;
		}

		/** [BlueBack.Mouse.Engine_Base]作成。
		*/
		public void Create()
		{
		}

		/** [BlueBack.Mouse.Engine_Base]削除。
		*/
		public void Delete()
		{
		}

		/** [BlueBack.Mouse.Engine_Base]更新。
		*/
		public void PreUpdate()
		{
			if(this.param.device != null){
				if(this.param.device.added == true){
					this.param.enable = true;
				}else{
					this.param.enable = false;
				}
			}else{
				this.param.enable = false;
			}
		}

		/** [BlueBack.Mouse.Engine_Base]GetCursorPos
		*/
		public UnityEngine.Vector2 GetCursorPos()
		{
			if(this.param.enable == true){
				UnityEngine.Vector2 t_raw = this.param.device.position.ReadValue();
				return new UnityEngine.Vector2(t_raw.x / UnityEngine.Screen.width,1.0f - t_raw.y / UnityEngine.Screen.height);
			}
			return new UnityEngine.Vector2(0.0f,0.0f);
		}

		/** [BlueBack.Mouse.Engine_Base]GetLeftButton
		*/
		public bool GetLeftButton()
		{
			if(this.param.enable == true){
				return this.param.device.leftButton.isPressed;
			}
			return false;
		}

		/** [BlueBack.Mouse.Engine_Base]GetRightButton
		*/
		public bool GetRightButton()
		{
			if(this.param.enable == true){
				return this.param.device.rightButton.isPressed;
			}
			return false;
		}

		/** [BlueBack.Mouse.Engine_Base]GetCenterButton
		*/
		public bool GetCenterButton()
		{
			if(this.param.enable == true){
				return this.param.device.middleButton.isPressed;
			}
			return false;
		}

		/** [BlueBack.Mouse.Engine_Base]GetWheelDelta
		*/
		public UnityEngine.Vector2 GetWheelDelta()
		{
			if(this.param.enable == true){
				return this.param.device.scroll.ReadValue();
			}
			return new UnityEngine.Vector2(0.0f,0.0f);
		}
	}
}
#endif

