#pragma once

// DXInfo.Ekey.ActiveX.h : DXInfo.Ekey.ActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CDXInfoEkeyActiveXApp : �й�ʵ�ֵ���Ϣ������� DXInfo.Ekey.ActiveX.cpp��

class CDXInfoEkeyActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

