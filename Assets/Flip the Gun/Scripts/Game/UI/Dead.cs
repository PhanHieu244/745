/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour {

	[Tooltip("Reward/Dead menu gameobject.")]
	public GameObject rewardMenu, deadMenu;
	[Tooltip("Coroutines gameobject.")]	
	public Coroutines coroutines;
	[Tooltip("High score text gameobject.")]	
	public Text highScoreTxt;
	[Tooltip("Dead score/highscore text gameobject.")]	
	public Text deadScoreTxt, deadHighScoreTxt;
	[Tooltip("Main camera object.")]	
	public Transform cameraPosition;

    void OnTriggerEnter2D(Collider2D col)
    {
		//If gun enters bottom collider.
        if (col.tag == "GunUI")
        {
			//If score is higher than highscore.
			if((int)cameraPosition.position.y/2 > Score.highScore)
			{
				//Set new highscore.
				Score.highScore = (int)cameraPosition.position.y/2;
				PlayerPrefs.SetInt("HighScore", Score.highScore);
				highScoreTxt.text = "BEST SCORE: " + Score.highScore.ToString();
				deadHighScoreTxt.text = "BEST SCORE: " + Score.highScore.ToString();
			}
			//Reset coin count(for rewards, challenges).
			Coin.coinCount=0;
			//Display score to device.
			deadScoreTxt.text = ((int)cameraPosition.position.y/2).ToString();	
			//If score is bigger than 100 then enable reward menu.
			if((int)cameraPosition.position.y/2 >= 100)
				rewardMenu.SetActive(true);
			//Otherwise display dead menu.
			else 
				deadMenu.SetActive(true);
			//Disable escape button.
			MainMenu.escape = 0;
		}
	}
}
