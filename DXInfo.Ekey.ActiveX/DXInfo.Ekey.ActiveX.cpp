// DXInfo.Ekey.ActiveX.cpp : CDXInfoEkeyActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "DXInfo.Ekey.ActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CDXInfoEkeyActiveXApp theApp;

const GUID CDECL _tlid = { 0xA4EB30E6, 0xD1B5, 0x437F, { 0x94, 0x36, 0x7F, 0x5D, 0x11, 0xD7, 0x27, 0x77 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CDXInfoEkeyActiveXApp::InitInstance - DLL 初始化

BOOL CDXInfoEkeyActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CDXInfoEkeyActiveXApp::ExitInstance - DLL 终止

int CDXInfoEkeyActiveXApp::ExitInstance()
{
	// TODO: 在此添加您自己的模块终止代码。

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - 将项添加到系统注册表

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - 将项从系统注册表中移除

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
