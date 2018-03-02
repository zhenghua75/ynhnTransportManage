// Key.cpp : CKey 的实现
#include "stdafx.h"
#include "Key.h"
#include "atlstr.h"
#include "DXInfoEkey.h"
// CKey


STDMETHODIMP CKey::Verify(VARIANT_BOOL* issuc)
{
	// TODO: 在此添加实现代码
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	//CString password("1a5ce5b0315c1a63937684df3253f73a");
	CString password("6e5bfbd7791441d4039ac25c73e5f1b1");
	CDXInfoEkey key(appName,password);
	*issuc = key.Verify();
	return S_OK;
}


STDMETHODIMP CKey::GetHardwareID(BSTR* hdId)
{
	// TODO: 在此添加实现代码
	CString strResult;

	// TODO: 在此添加调度处理程序代码
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	//CString password("1a5ce5b0315c1a63937684df3253f73a");
	CString password("6e5bfbd7791441d4039ac25c73e5f1b1");
	CDXInfoEkey key(appName,password);
	char hardwareID[64];
	key.GetHardwareID(hardwareID);
	strResult=hardwareID;
	*hdId = strResult.AllocSysString();
	return S_OK;
}


STDMETHODIMP CKey::GetKeyNo(BSTR* data)
{
	// TODO: 在此添加实现代码

	CString strResult;
	CString appName("ynhnTransport");
	CString password("6e5bfbd7791441d4039ac25c73e5f1b1");
	CDXInfoEkey key(appName,password);
	unsigned char keyno[128];
	key.GetKeyNo(keyno);
	strResult=keyno;
	*data = strResult.AllocSysString();
	return S_OK;
}
