// DXInfo.Ekey.ActiveXCtrl.cpp : CDXInfoEkeyActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "DXInfo.Ekey.ActiveX.h"
#include "DXInfo.Ekey.ActiveXCtrl.h"
#include "DXInfo.Ekey.ActiveXPropPage.h"
#include "afxdialogex.h"

#include "DXInfo.Ekey.h"
#include "NT77Api.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoEkeyActiveXCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "Verify", dispidVerify, Verify, VT_BOOL, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "GetHardwareID", dispidGetHardwareID, GetHardwareID, VT_BSTR, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CDXInfoEkeyActiveXCtrl, 1)
	PROPPAGEID(CDXInfoEkeyActiveXPropPage::guid)
END_PROPPAGEIDS(CDXInfoEkeyActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CDXInfoEkeyActiveXCtrl, "DXINFOEKEYACTIVE.DXInfoEkeyActiveCtrl.1",
	0x5790c5f1, 0xaaf8, 0x4e72, 0xbd, 0xe7, 0x86, 0x5, 0xa5, 0, 0xa, 0xd4)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CDXInfoEkeyActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID IID_DDXInfoEkeyActiveX = { 0x42E5B082, 0xDE9, 0x437B, { 0xBB, 0xF3, 0xF7, 0x79, 0xDE, 0xA9, 0x9A, 0x33 } };
const IID IID_DDXInfoEkeyActiveXEvents = { 0xC719E07A, 0x1214, 0x4536, { 0xB7, 0x17, 0x25, 0xE3, 0xC2, 0xEC, 0xBF, 0x91 } };


// �ؼ�������Ϣ

static const DWORD _dwDXInfoEkeyActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CDXInfoEkeyActiveXCtrl, IDS_DXINFOEKEYACTIVEX, _dwDXInfoEkeyActiveXOleMisc)



// CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CDXInfoEkeyActiveXCtrl ��ϵͳע�����

BOOL CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: ��֤���Ŀؼ��Ƿ���ϵ�Ԫģ���̴߳������
	// �йظ�����Ϣ����ο� MFC ����˵�� 64��
	// ������Ŀؼ������ϵ�Ԫģ�͹�����
	// �����޸����´��룬��������������
	// afxRegApartmentThreading ��Ϊ 0��

	if (bRegister)
		return AfxOleRegisterControlClass(
			AfxGetInstanceHandle(),
			m_clsid,
			m_lpszProgID,
			IDS_DXINFOEKEYACTIVEX,
			IDB_DXINFOEKEYACTIVEX,
			afxRegApartmentThreading,
			_dwDXInfoEkeyActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrl - ���캯��

CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrl()
{
	InitializeIIDs(&IID_DDXInfoEkeyActiveX, &IID_DDXInfoEkeyActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CDXInfoEkeyActiveXCtrl::~CDXInfoEkeyActiveXCtrl - ��������

CDXInfoEkeyActiveXCtrl::~CDXInfoEkeyActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CDXInfoEkeyActiveXCtrl::OnDraw - ��ͼ����

void CDXInfoEkeyActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CDXInfoEkeyActiveXCtrl::DoPropExchange - �־���֧��

void CDXInfoEkeyActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CDXInfoEkeyActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CDXInfoEkeyActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CDXInfoEkeyActiveXCtrl::AboutBox - ���û���ʾ�����ڡ���

void CDXInfoEkeyActiveXCtrl::AboutBox()
{
	CDialogEx dlgAbout(IDD_ABOUTBOX_DXINFOEKEYACTIVEX);
	dlgAbout.DoModal();
}



// CDXInfoEkeyActiveXCtrl ��Ϣ�������


VARIANT_BOOL CDXInfoEkeyActiveXCtrl::Verify(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	CString password("1a5ce5b0315c1a63937684df3253f73a");
	CDXInfoEkey key(appName,password);
	return key.Verify();
}


BSTR CDXInfoEkeyActiveXCtrl::GetHardwareID(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	CString password("1a5ce5b0315c1a63937684df3253f73a");
	CDXInfoEkey key(appName,password);
	char hardwareID[64];
	key.GetHardwareID(hardwareID);
	strResult=hardwareID;
	return strResult.AllocSysString();
}
