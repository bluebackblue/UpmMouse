# BlueBack.Mouse
マウス操作
* マウスの位置、ボタン、ホイールの取得
* FixedUpdateでのダウン、アップ、連射の取得

## ライセンス
MIT License
* https://github.com/bluebackblue/UpmMouse/blob/main/LICENSE

## 依存 / 使用ライセンス等
### ランタイム
### エディター
* https://github.com/bluebackblue/UpmMouse
### サンプル
* https://github.com/bluebackblue/UpmMouse

## 動作確認
Unity 2021.1.11f1

## UPM
### 最新
* https://github.com/bluebackblue/UpmMouse.git?path=BlueBackMouse/Assets/UPM#0.0.14
### 開発
* https://github.com/bluebackblue/UpmMouse.git?path=BlueBackMouse/Assets/UPM

## Unityへの追加方法
* Unity起動
* メニュー選択：「Window->Package Manager」
* ボタン選択：「左上の＋ボタン」
* リスト選択：「Add package from git URL...」
* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」
### 注
Gitクライアントがインストールされている必要がある。
* https://docs.unity3d.com/ja/current/Manual/upm-git.html
* https://git-scm.com/

## 例
```
/** Update用。
*/
private BlueBack.Mouse.Mouse mouse;

/** FixedUpdate用。
*/
private BlueBack.Mouse.Mouse mouse_fixedupdate;

/** Start
*/
private void Start()
{
	//Update用。
	this.mouse = new BlueBack.Mouse.Mouse(BlueBack.Mouse.Mode.Update,BlueBack.Mouse.InitParam.CreateDefault());

	//FixedUpdate用。
	this.mouse_fixedupdate = new BlueBack.Mouse.Mouse(BlueBack.Mouse.Mode.FixedUpdate,BlueBack.Mouse.InitParam.CreateDefault());
}

/** Update
*/
private void Update()
{
	if(this.mouse.left.down == true){
		UnityEngine.Debug.Log("Update.Left.Down");
	}
}

/** FixedUpdate
*/
private void FixedUpdate()
{
	if(this.mouse_fixedupdate.left.down == true){
		UnityEngine.Debug.Log("FixedUpdate.Left.Down");
	}
}
```
