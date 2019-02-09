package com.zyfdroid.touhouremotectl;

import android.view.*;
import android.widget.*;
import android.app.*;
import android.os.*;
import android.content.*;
import java.net.*;
import java.io.*;

public class MainActivity extends BaseActivity 
{
	@Override
	public void onPrepareUi()
	{
		setContentView(R.layout.main);
		setViewText(R.id.txtIp,load("ip"));
		//禁止严格模式，允许在主线程上搞网络操作
		if (android.os.Build.VERSION.SDK_INT > 9) {
			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
			StrictMode.setThreadPolicy(policy);
		}
	}
	@Override
	public void onBackPressed()
	{
		save("ip",getViewText(R.id.txtIp));
		super.onBackPressed();
	}

	public void connect(View view){
		save("ip",getViewText(R.id.txtIp));
		try
		{
			SocketClient.disposeInstance();
			SocketClient.IpAddress=getViewText(R.id.txtIp);
			SocketClient.getInstance().send(OperateStruct.result);
		}
		catch (UnknownHostException e)
		{
			toast("无法解析目标电脑的地址。详情:" + e.getLocalizedMessage());
		}
		catch (SocketException e)
		{
			toast("建立网络通信失败。详情:" + e.getLocalizedMessage());
		}
		catch (IOException e)
		{
			toast("数据传输失败。详情:" + e.getLocalizedMessage());
		}
		finally{
			startActivity(new Intent(this,ControlActivity.class));
		}
	}
	@Override
	public boolean isImmerseMode()
	{
		return true;
	}
	
	
}



