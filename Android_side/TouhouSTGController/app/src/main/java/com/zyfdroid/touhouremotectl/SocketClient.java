package com.zyfdroid.touhouremotectl;
import java.net.*;
import java.io.*;

public class SocketClient
{
	public static String IpAddress="";
	
	private static SocketClient mInstance=null;
	private DatagramSocket mSocket;
	private DatagramPacket mPacket;
	private SocketClient(String ip) throws SocketException, UnknownHostException
	{
		mSocket = new DatagramSocket();
		mPacket = new DatagramPacket(new byte[2], 2, InetAddress.getByName(ip), 0x3389);
	}
	
	public static SocketClient getInstance() throws UnknownHostException, SocketException{
		if(null==mInstance){
			mInstance=new SocketClient(IpAddress);
		}
		return mInstance;
	}
	public static void disposeInstance(){
		if(mInstance==null){return;}
		mInstance.mSocket.close();
		mInstance=null;
	}
	
	public void send(byte[] b) throws IOException
	{
		mPacket.setData(b, 0, 2);
		mSocket.send(mPacket);
	}
	
}
