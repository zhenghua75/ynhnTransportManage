// DXInfo.Card.ActvieX.cpp : CDXInfoCardActvieXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CDXInfoCardActvieXApp theApp;

const GUID CDECL _tlid = { 0x7E00785F, 0x34DD, 0x4877, { 0xB7, 0x3D, 0xD1, 0x33, 0x75, 0x14, 0x13, 0x58 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CDXInfoCardActvieXApp::InitInstance - DLL 初始化

BOOL CDXInfoCardActvieXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CDXInfoCardActvieXApp::ExitInstance - DLL 终止

int CDXInfoCardActvieXApp::ExitInstance()
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
