#pragma once

// DXInfo.Card.ActvieX.h : DXInfo.Card.ActvieX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CDXInfoCardActvieXApp : �й�ʵ�ֵ���Ϣ������� DXInfo.Card.ActvieX.cpp��

class CDXInfoCardActvieXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

