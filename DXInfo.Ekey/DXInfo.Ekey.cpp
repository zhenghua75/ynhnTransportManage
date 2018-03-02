// DXInfo.Ekey.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "DXInfo.Ekey.h"
#include "NT77Api.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// Ψһ��Ӧ�ó������

CWinApp theApp;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	HMODULE hModule = ::GetModuleHandle(NULL);

	if (hModule != NULL)
	{
		// ��ʼ�� MFC ����ʧ��ʱ��ʾ����
		if (!AfxWinInit(hModule, NULL, ::GetCommandLine(), 0))
		{
			// TODO: ���Ĵ�������Է���������Ҫ
			_tprintf(_T("����: MFC ��ʼ��ʧ��\n"));
			nRetCode = 1;
		}
		else
		{
			// TODO: �ڴ˴�ΪӦ�ó������Ϊ��д���롣
		}
	}
	else
	{
		// TODO: ���Ĵ�������Է���������Ҫ
		_tprintf(_T("����: GetModuleHandle ʧ��\n"));
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