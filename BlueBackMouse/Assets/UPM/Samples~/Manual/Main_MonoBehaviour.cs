

/** define
*/
#define MOUSE_UPDATE
#define MOUSE_FIXEDUPDATE
#define MOUSE_MANUAL


/** BlueBack.Mouse.Samples.Manual
*/
#if(!DEF_BLUEBACK_MOUSE_SAMPLES_DISABLE)
namespace BlueBack.Mouse.Samples.Manual
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** mouse_update
		*/
		#if(MOUSE_UPDATE)
		private BlueBack.Mouse.Mouse mouse_update;
		#endif

		/** mouse_fixedupdate
		*/
		#if(MOUSE_FIXEDUPDATE)
		private BlueBack.Mouse.Mouse mouse_fixedupdate;
		#endif

		/** マニュアル呼び出し。
		*/
		#if(MOUSE_MANUAL)
		private BlueBack.Mouse.Mouse mouse_manual;
		#endif

		/** 表示。
		*/
		#if(MOUSE_UPDATE)
		private UnityEngine.UI.Text text_update;
		private int value_update;
		private UnityEngine.Vector2 value_wheel_update;
		#endif

		#if(MOUSE_FIXEDUPDATE)
		private UnityEngine.UI.Text text_fixedupdate;
		private int value_fixedupdate;
		private UnityEngine.Vector2 value_wheel_fixedupdate;
		#endif

		#if(MOUSE_MANUAL)
		private UnityEngine.UI.Text text_manual;
		private int value_manual;
		private UnityEngine.Vector2 value_wheel_manual;
		#endif

		/** Start
		*/
		private void Start()
		{
			BlueBack.Mouse.UIM.InitParam t_initparam_uim = BlueBack.Mouse.UIM.InitParam.CreateDefault();

			//Update用。
			#if(MOUSE_UPDATE)
			{
				BlueBack.Mouse.InitParam t_initparam = BlueBack.Mouse.InitParam.CreateDefault();
				{
					t_initparam.updatemode = UpdateMode.UnityUpdate;
					t_initparam.engine = new BlueBack.Mouse.UIM.Engine(t_initparam_uim);
				}
				this.mouse_update = new BlueBack.Mouse.Mouse(in t_initparam);
				this.text_update = UnityEngine.GameObject.Find("Text_Update").GetComponent<UnityEngine.UI.Text>();
				this.value_update = 0;
				this.value_wheel_update = new UnityEngine.Vector2(0.0f,0.0f);
			}
			#endif

			//FixedUpdate用。
			#if(MOUSE_FIXEDUPDATE)
			{
				BlueBack.Mouse.InitParam t_initparam = BlueBack.Mouse.InitParam.CreateDefault();
				{
					t_initparam.updatemode = UpdateMode.UnityFixedUpdate;
					t_initparam.engine = new BlueBack.Mouse.UIM.Engine(t_initparam_uim);
				}
				this.mouse_fixedupdate = new BlueBack.Mouse.Mouse(in t_initparam);
				this.text_fixedupdate = UnityEngine.GameObject.Find("Text_FixedUpdate").GetComponent<UnityEngine.UI.Text>();
				this.value_fixedupdate = 0;
				this.value_wheel_fixedupdate = new UnityEngine.Vector2(0.0f,0.0f);
			}
			#endif

			//マニュアル呼び出し。
			#if(MOUSE_MANUAL)
			{
				BlueBack.Mouse.InitParam t_initparam = BlueBack.Mouse.InitParam.CreateDefault();
				{
					t_initparam.updatemode = UpdateMode.ManualUpdate;
					t_initparam.engine = new BlueBack.Mouse.UIM.Engine(t_initparam_uim);
				}
				this.mouse_manual = new BlueBack.Mouse.Mouse(in t_initparam);
				this.text_manual = UnityEngine.GameObject.Find("Text_Manual").GetComponent<UnityEngine.UI.Text>();
				this.value_manual = 0;
				this.value_wheel_manual = new UnityEngine.Vector2(0.0f,0.0f);
			}
			#endif

			//表示。
			UnityEngine.Application.targetFrameRate = 10;
		}

		/** Update
		*/
		private void Update()
		{
			#if(MOUSE_UPDATE)

			if(this.mouse_update.left.rapid == true){
				this.value_update++;
			}

			if(this.mouse_update.right.down == true){
				this.value_update--;
			}

			if(this.mouse_update.center.up == true){
				this.value_update = 0;
			}

			this.value_wheel_update += this.mouse_update.wheel.pos;

			#endif
		}

		/** FixedUpdate
		*/
		private void FixedUpdate()
		{
			#if(MOUSE_FIXEDUPDATE)

			if(this.mouse_fixedupdate.left.rapid == true){
				this.value_fixedupdate++;
			}
			if(this.mouse_fixedupdate.right.down == true){
				this.value_fixedupdate--;
			}
			if(this.mouse_fixedupdate.center.up == true){
				this.value_fixedupdate = 0;
			}

			this.value_wheel_fixedupdate += this.mouse_fixedupdate.wheel.pos;

			#endif
		}

		/** LateUpdate
		*/
		private void LateUpdate()
		{
			#if(MOUSE_MANUAL)

			//マニュアル呼び出し。
			this.mouse_manual.ManualUpdate();

			if(this.mouse_manual.left.rapid == true){
				this.value_manual++;
			}
			if(this.mouse_manual.right.down == true){
				this.value_manual--;
			}
			if(this.mouse_manual.center.up == true){
				this.value_manual = 0;
			}

			this.value_wheel_manual += this.mouse_manual.wheel.pos;

			#endif

			#if(MOUSE_UPDATE)
			this.text_update.text		= string.Format("Update      {0} {1} {2} {3:0.000} {4:0.000}",this.value_update,this.value_wheel_update.x,this.value_wheel_update.y,this.mouse_update.cursor.pos.x,this.mouse_update.cursor.pos.y);
			#endif

			#if(MOUSE_FIXEDUPDATE)
			this.text_fixedupdate.text	= string.Format("FixedUpdate {0} {1} {2} {3:0.000} {4:0.000}",this.value_fixedupdate,this.value_wheel_fixedupdate.x,this.value_wheel_fixedupdate.y,this.mouse_fixedupdate.cursor.pos.x,this.mouse_fixedupdate.cursor.pos.y);
			#endif

			#if(MOUSE_MANUAL)
			this.text_manual.text		= string.Format("Manual      {0} {1} {2} {3:0.000} {4:0.000}",this.value_manual,this.value_wheel_manual.x,this.value_wheel_manual.y,this.mouse_manual.cursor.pos.x,this.mouse_manual.cursor.pos.y);
			#endif
		}
	}
}
#endif

