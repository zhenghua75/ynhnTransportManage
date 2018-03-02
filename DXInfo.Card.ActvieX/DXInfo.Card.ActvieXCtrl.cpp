// DXInfo.Card.ActvieXCtrl.cpp : CDXInfoCardActvieXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"
#include "DXInfo.Card.ActvieXCtrl.h"
#include "DXInfo.Card.ActvieXPropPage.h"
#include "afxdialogex.h"
#include "DXInfo.Card.h"
//#include "mwrf32.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoCardActvieXCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CDXInfoCardActvieXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CDXInfoCardActvieXCtrl, COleControl)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "ReadCard", dispidReadCard, ReadCard, VT_BSTR, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "PutCard", dispidPutCard, PutCard, VT_BOOL, VTS_BSTR)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "Write", dispidWrite, Write, VT_BOOL, VTS_BSTR)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "RecycleCard", dispidRecycleCard, RecycleCard, VT_BOOL, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CDXInfoCardActvieXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CDXInfoCardActvieXCtrl, 1)
	PROPPAGEID(CDXInfoCardActvieXPropPage::guid)
END_PROPPAGEIDS(CDXInfoCardActvieXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CDXInfoCardActvieXCtrl, "DXINFOCARDACTVIE.DXInfoCardActvieCtrl.1",
	0x43246d5d, 0x8e72, 0x43c9, 0xba, 0xb1, 0xee, 0x73, 0x3c, 0x3d, 0xdc, 0xa4)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CDXInfoCardActvieXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID IID_DDXInfoCardActvieX = { 0x4E12BC45, 0xD49E, 0x400D, { 0x86, 0xFA, 0xDE, 0x5D, 0x29, 0x13, 0x2B, 0xF1 } };
const IID IID_DDXInfoCardActvieXEvents = { 0xBAB78D8C, 0x29BA, 0x4661, { 0xB1, 0xA4, 0x91, 0x51, 0x72, 0x76, 0x41, 0x7D } };


// �ؼ�������Ϣ

static const DWORD _dwDXInfoCardActvieXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CDXInfoCardActvieXCtrl, IDS_DXINFOCARDACTVIEX, _dwDXInfoCardActvieXOleMisc)



// CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CDXInfoCardActvieXCtrl ��ϵͳע�����

BOOL CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_DXINFOCARDACTVIEX,
			IDB_DXINFOCARDACTVIEX,
			afxRegApartmentThreading,
			_dwDXInfoCardActvieXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrl - ���캯��

CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrl()
{
	InitializeIIDs(&IID_DDXInfoCardActvieX, &IID_DDXInfoCardActvieXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CDXInfoCardActvieXCtrl::~CDXInfoCardActvieXCtrl - ��������

CDXInfoCardActvieXCtrl::~CDXInfoCardActvieXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CDXInfoCardActvieXCtrl::OnDraw - ��ͼ����

void CDXInfoCardActvieXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CDXInfoCardActvieXCtrl::DoPropExchange - �־���֧��

void CDXInfoCardActvieXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CDXInfoCardActvieXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CDXInfoCardActvieXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CDXInfoCardActvieXCtrl::AboutBox - ���û���ʾ�����ڡ���

void CDXInfoCardActvieXCtrl::AboutBox()
{
	CDialogEx dlgAbout(IDD_ABOUTBOX_DXINFOCARDACTVIEX);
	dlgAbout.DoModal();
}


BSTR CDXInfoCardActvieXCtrl::ReadCard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;
	
	// TODO: �ڴ���ӵ��ȴ���������
	unsigned char data[33];
	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("B01B4C49A3D3");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.ReadCard(data))
		strResult.Format("%s",data);
	else
		strResult="";
	return strResult.AllocSysString();
}



VARIANT_BOOL CDXInfoCardActvieXCtrl::PutCard(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	/*CString akey_old("FFFFFFFFFFFF");
	CString bkey_old("FFFFFFFFFFFF");*/
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("C03F5591EB08");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.PutCard((unsigned char*)data))
		return VARIANT_TRUE;
	else
		return VARIANT_FALSE;
}


VARIANT_BOOL CDXInfoCardActvieXCtrl::Write(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	return VARIANT_TRUE;
}


VARIANT_BOOL CDXInfoCardActvieXCtrl::RecycleCard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	/*CString akey_old("FFFFFFFFFFFF");
	CString bkey_old("FFFFFFFFFFFF");*/
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("C03F5591EB08");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.RecycleCard())
		return VARIANT_TRUE;
	else
		return VARIANT_FALSE;
}
