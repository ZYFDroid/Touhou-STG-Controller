package com.zyfdroid.touhouremotectl;

import android.app.*;
import android.content.*;
import android.content.res.*;
import android.graphics.*;
import android.graphics.drawable.*;
import android.media.*;
import android.os.*;
import android.text.*;
import android.util.*;
import android.view.*;
import android.widget.*;
import java.io.*;

public abstract class BaseActivity extends Activity
{
	//AIDE魔改版里自带的模板，整理了一下需要的东西

	public static  int FPS=60;
	Thread FrameThread;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		if (isHiddenTitleBar())
		{this.requestWindowFeature(Window.FEATURE_NO_TITLE);}
		if (isFullScreen())
		{this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);		}
		if (isImmerseMode())
		{onHide();}
		FrameThread = new Thread(new Runnable(){

				@Override
				public void run()
				{
					Runnable UiTask=new Runnable(){

						@Override
						public void run()
						{
							onFrame();
						}
					};
					int spf=1000 / FPS;
					while (true)
					{
						try
						{
							Thread.sleep(spf);
							runOnUiThread(UiTask);
						}
						catch (InterruptedException e)
						{return;}
					}

				}
			});
		onPrepareUi();
	}
	boolean isCreating=true;
	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		if (isCreating)
		{
			isCreating = false;
			onUiPrepared();
			FrameThread.start();
		}
		if (hasFocus && isImmerseMode())
		{
			onHide();
		}
	}

	@Override
	protected void onDestroy()
	{
		FrameThread.interrupt();
		super.onDestroy();

	}

	//设置沉浸模式
	public void onHide()
	{
		int flags = View.SYSTEM_UI_FLAG_LAYOUT_STABLE
            | View.SYSTEM_UI_FLAG_FULLSCREEN
            | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
            | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION;


		if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT)
		{
			getWindow().getDecorView().setSystemUiVisibility(
                flags | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
				| View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
			);
		}
		else if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN)
		{
			getWindow().getDecorView().setSystemUiVisibility(flags);
		}
	}
	
	public abstract void onPrepareUi();
	public void onUiPrepared(){}
	public void onFrame(){}
	public boolean isHiddenTitleBar()
	{
		return false;
	}
	public boolean isFullScreen()
	{
		return false;
	}
	public boolean isImmerseMode()
	{
		return false;
	}
	public String getViewText(int id){
		return ((TextView)findViewById(id)).getText().toString();
	}
	public void setViewText(int id,String value){
		((TextView)findViewById(id)).setText(value);
	}
	public void save(String key,String value){
		getSharedPreferences("main",MODE_PRIVATE).edit().putString(key,value).commit();
	}
	public String load(String key){
		return getSharedPreferences("main",MODE_PRIVATE).getString(key,"");
	}
	public void toast(String msg){
		Toast.makeText(this,msg,msg.length()>30 ? Toast.LENGTH_LONG : Toast.LENGTH_SHORT).show();
	}
	
}
