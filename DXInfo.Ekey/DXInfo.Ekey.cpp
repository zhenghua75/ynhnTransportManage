// DXInfo.Ekey.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "DXInfo.Ekey.h"
#include "NT77Api.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 唯一的应用程序对象

CWinApp theApp;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	HMODULE hModule = ::GetModuleHandle(NULL);

	if (hModule != NULL)
	{
		// 初始化 MFC 并在失败时显示错误
		if (!AfxWinInit(hModule, NULL, ::GetCommandLine(), 0))
		{
			// TODO: 更改错误代码以符合您的需要
			_tprintf(_T("错误: MFC 初始化失败\n"));
			nRetCode = 1;
		}
		else
		{
			// TODO: 在此处为应用程序的行为编写代码。
		}
	}
	else
	{
		// TODO: 更改错误代码以符合您的需要
		_tprintf(_T("错误: GetModuleHandle 失败\n"));
		nRetCode = 1;
	}

	return nRetCode;
}

CDXInfoEkey::CDXInfoEkey(CString projName,CString pwd)
{
	m_projName=projName;
	m_pwd=pwd;
}
bool CDXInfoEkey::Verify(void)
{
	long nRet = 0;
	nRet = NTFindFirst(m_projName.GetBuffer());
	if(0 != nRet)
	{
		return false;
	}

	nRet = NTLogin(m_pwd.GetBuffer());
	if( 0 != nRet)
	{
		return false;
	}
	nRet = NTLogout();
	if( 0 != nRet)
	{
		return false;
	}
	return true;
}
bool CDXInfoEkey::GetHardwareID(char hdID[64])
{
	long nRet = 0;
	//char hwID[64];	
	memset(hdID,0,64);
	nRet = NTFindFirst(m_projName.GetBuffer());
	if(0 != nRet)
	{
		return false;
	}
	nRet = NTLogin(m_pwd.GetBuffer());
	if( 0 != nRet)
	{
		return false;
	}
	nRet = NTGetHardwareID(hdID);	
	if( 0 != nRet)
	{
		return false;
	}
	//hardwareID = hwID;
	nRet = NTLogout();
	if( 0 != nRet)
	{
		return false;
	}
	return true;
}