// DXInfo.Card.ActvieX.cpp : CDXInfoCardActvieXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CDXInfoCardActvieXApp theApp;

const GUID CDECL _tlid = { 0x7E00785F, 0x34DD, 0x4877, { 0xB7, 0x3D, 0xD1, 0x33, 0x75, 0x14, 0x13, 0x58 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CDXInfoCardActvieXApp::InitInstance - DLL ��ʼ��

BOOL CDXInfoCardActvieXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CDXInfoCardActvieXApp::ExitInstance - DLL ��ֹ

int CDXInfoCardActvieXApp::ExitInstance()
{
	// TODO: �ڴ�������Լ���ģ����ֹ���롣

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - ������ӵ�ϵͳע���

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - �����ϵͳע������Ƴ�

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
